using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionDemo
{
    public class Lot
    {
        public Guid Id { get; } // Уникальный идентификатор
        public string Title { get; } // Название
        public decimal StartPrice { get; } // Начальная цена
        public decimal BidStep { get; } // Шаг ставки
        public decimal? CurrentBid { get; private set; } = default; // Последняя ставка и может хранить null
        public string? CurrentLeader { get; private set; } = default; // Имя лидера
        public decimal? BuyNowPrice { get; } // Цена мгновенного выкупа
        public DateTime EndsAt { get; } // Время окончания торгов

        //public Action<string, decimal>? BidPlaced;//  Для оповещения Ставка

        //public Action<string, decimal>? Repurchase;//  Для оповещения, что произошёл мгновенный выкуп

        public event EventHandler<BidPlacedEventArgs>? BidPlaced; // для оповещения Ставка

        public event EventHandler<BuyNowTriggerEventArgs>? Repurchased;

        public Lot(string title, decimal startPrice, decimal bidStep,
            DateTime endsAt, decimal? buyNowPrice = default)
        {
            Id = Guid.NewGuid();
            Title = title;
            StartPrice = startPrice;
            BidStep = bidStep;
            EndsAt = endsAt;
            BuyNowPrice = buyNowPrice;
        }

        public void BuyNow(string buyer)
        {
            //	фиксирует продажу(можно просто вывести в консоль «лот выкуплен» и запомнить победителя);
            //	оповещает подписчиков — но вот вопрос: через BidPlaced? Или нужен новый делегат? Реши сам и напиши, почему выбрал так.
            if (BuyNowPrice is null || EndsAt < DateTime.UtcNow)
                throw new InvalidOperationException("Вы не можете выкупить этот лот");

            if (CurrentBid is null || CurrentBid < BuyNowPrice)
            {
                CurrentBid = BuyNowPrice;
                CurrentLeader = buyer;
                // Оповещаем о мгновенном выкупе лота
                //Repurchased(buyer, BuyNowPrice!.Value); // Проблема
                OnBuyNowTrigger(new BuyNowTriggerEventArgs(buyer, CurrentBid!.Value));
                return;
            }
            throw new InvalidOperationException("Вы не можете выкупить этот лот");

        }

        protected virtual void OnBuyNowTrigger(BuyNowTriggerEventArgs e) => Repurchased?.Invoke(this, e);

        public void PlaceBid(string bidder, decimal amount)
        {
            if (DateTime.UtcNow >= EndsAt)
                throw new InvalidOperationException("Торги уже завершены");

            if (CurrentBid is null && amount < StartPrice)
                throw new InvalidOperationException("Ставка слишком мала");

            if (CurrentBid is not null && amount < CurrentBid + BidStep)
                throw new InvalidOperationException("Ставка слишком мала");

            var previousBid = CurrentBid;
            var previousLeader = CurrentLeader;

            CurrentBid = amount;
            CurrentLeader = bidder;

            /*BidPlaced(bidder, amount);*/ // Проблема! Если никто не подписался, то исключение
                                           // Уведомляем тех, кто подписался на это событие, что ставка произошла
            OnBidPlaced(new BidPlacedEventArgs(Title, bidder, amount, previousBid, previousLeader));
        }

        protected virtual void OnBidPlaced(BidPlacedEventArgs e) => BidPlaced?.Invoke(this, e);
    }
}
