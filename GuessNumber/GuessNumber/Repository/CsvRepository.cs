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
            if(filepath == null || filepath == "") { throw new ArgumentNullException(nameof(filepath)); }
            _filepath = filepath;
            _accountpath = Path.Combine(_filepath, "accdata.csv");
            _statspath = Path.Combine(_filepath, "statsdata.csv");
            CreateFileIfNotExists(_accountpath);
            CreateFileIfNotExists(_statspath);
        }
        public PersonAccount? ReadAccountFromRep(string Login)
        {
            string[] lines = File.ReadAllLines(_accountpath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3) continue;
                if (parts[1].ToLower() == Login.ToLower())
                {
                    if(Guid.TryParse(parts[0], out Guid id))
                    {
                        return new PersonAccount(id, parts[1], parts[2]);
                    }
                    throw new InvalidDataException($"Corrupted account id, login corrupted account: {line} in {_accountpath}");
                }
            }
            return null;
        }
        public bool WriteAccountToRep(PersonAccount account)
        {
            if(account is null) { throw new ArgumentNullException(nameof(account)); }
            if (ReadAccountFromRep(account.Login) is not null)
            {
                return false;
            }
            string line = string.Join(",", account.Id,account.Login, account.Name);
            File.AppendAllText(_accountpath,line+Environment.NewLine);
            return true;
        }
        public GlobalStatistics? ReadStatsPlayerFromRep(Guid id)
        {
            string[] lines = File.ReadAllLines(_statspath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length <4) continue;
                if (Guid.TryParse(parts[0], out Guid res))
                {
                    if (id == res)
                    {
                        return new GlobalStatistics(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                    }
                }


            }
            return null;
        }
        public bool WriteStatsPlayerToRep( Guid id, GlobalStatistics stats)
        {
            if (stats is null) { throw new ArgumentNullException(nameof(stats)); }
            string line = string.Join(",", id, stats.Wins, stats.Streak, stats.BestStreak);
            if (ReadStatsPlayerFromRep(id) is not null)
            {
               string[] lines = File.ReadAllLines(_statspath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length < 4) continue;
                    if (Guid.TryParse(parts[0], out Guid res))
                    {
                        if (id == res)
                        {
                            lines[i] = line;
                            break;
                        }
                    }
                }
                File.WriteAllLines(_statspath+".tmp", lines);
                File.Replace(_statspath + ".tmp", _statspath, null);
                return true;
            }
            File.AppendAllText(_statspath, line + Environment.NewLine);
            return true;
        }
        private void CreateFileIfNotExists(string path)
        {
            if (!File.Exists(path))
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                File.Create(path).Dispose();
            }
        }
    }
}
