using GuessNumber.core.Account;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Repository
{
    public class CsvRepository : IAccountRepository,IPlayerStatsRepository
    {
        private readonly string _filepath;
        private string _accountpath;

        private string _statspath;
        public CsvRepository(string filepath)
        {
            if(filepath == null) { throw new ArgumentNullException(nameof(filepath)); }
            _filepath = filepath;
            _accountpath = Path.Combine(_filepath, "accdata.csv");
            _statspath = Path.Combine(_filepath, "statsdata.csv");
        }
        public PersonAccount? Read(string Login)
        {
            if (!File.Exists(_accountpath))
            {
                Directory.CreateDirectory(_accountpath);
                File.Create("accdata.csv");
            }
            string[] lines = File.ReadAllLines(_accountpath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3) continue;
                if (parts[1] == Login)
                {
                    if(Guid.TryParse(parts[0], out Guid id))
                    {
                        return new PersonAccount(id, parts[1], parts[2]);
                    }
                }
            }
            return null;
        }
        public bool Write(PersonAccount account)
        {
            if(account is null) { throw new ArgumentNullException(nameof(account)); }
            if (!File.Exists(_accountpath))
            {
                Directory.CreateDirectory(_accountpath);
                File.Create("accdata.csv");
            }
            if (Read(account.Login) is not null)
            {
                return false;
            }
            string line = string.Join(",", account.Id,account.Login, account.Name);
            File.AppendAllText(_accountpath,line);
            return true;
        }
        public GlobalStatistics? Get(Guid id)
        {
            if (!File.Exists(_statspath))
            {
                Directory.CreateDirectory(_statspath);
                File.Create("statsdata.csv");
            }
            string[] lines = File.ReadAllLines(_statspath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 4) continue;
                if (Guid.Parse(parts[0])== id)
                {
                    return new GlobalStatistics(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                }
            }
            return null;
        }
        public bool Save( Guid id, GlobalStatistics stats)
        {
            if (stats is null) { throw new ArgumentNullException(nameof(stats)); }
            {
                Directory.CreateDirectory(_statspath);
                File.Create("statsdata.csv");
            }
            if (Get(id) is not null)
            {
                return false;
            }
            string line = string.Join(",",id,stats.Wins,stats.Streak,stats.BestStrike);
            File.AppendAllText(_statspath, line);
            return true;
        }
    }
}
