using System.Collections.Generic;

namespace LandLystLib
{
    public class Room
    {
        private List<RoomAddition> additions = new List<RoomAddition>();
        private string additionsDescription;
        private int number;
        private double roomPrice, additionsPrice, totalPrice;

        public List<RoomAddition> Additions
        {
            get { return additions; }
        }
        public string AdditionsDescription
        {
            get { return additionsDescription; }
        }
        public int Number
        {
            get { return number; }
        }
        public double RoomPrice
        {
            get { return roomPrice; }
        }
        public double AdditionPrice
        {
            get { return additionsPrice; }
        }
        public double TotalPrice
        {
            get { return totalPrice; }
        }

        public Room(List<RoomAddition> additions, int number, double roomPrice = 695.0)
        {
            this.additions = additions;
            this.number = number;
            this.roomPrice = roomPrice;

            SetPrices();
            SetAdditionsDescription();
        }

        /// <summary>
        /// Used to check if additions exist in room
        /// </summary>
        internal bool CheckAdditionsFilter(List<string> additionsFilter)
        {
            bool doesAdditionExist = false;

            // Loops through additions filter
            for (int j = 0; j < additionsFilter.Count; j++)
            {
                doesAdditionExist = false;

                // Loops through additions from current room to check if they matchup with the filter
                for (int k = 0; k < Additions.Count; k++)
                    if (Additions[k].Addtion == additionsFilter[j])
                        doesAdditionExist = true;

                // If none of the filter additions exists in current room, break
                if (!doesAdditionExist)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Used to se discount on room
        /// </summary>
        public void SetDiscount(int days, int discountDay, double procent)
        {
            if (days >= discountDay)
            {
                roomPrice = (roomPrice / 100.0) * (100.0 - procent);
                additionsPrice = (additionsPrice / 100.0) * (100.0 - procent);
                totalPrice = (totalPrice / 100.0) * (100.0 - procent);
            }
        }
 
        /// <summary>
        /// Used to set prices
        /// </summary>
        private void SetPrices()
        {
            totalPrice = 0;
            additionsPrice = 0;

            // Adds room base price to total price
            totalPrice += roomPrice;

            // Adds room addition prices to room price
            for (int i = 0; i < additions.Count; i++)
                additionsPrice += additions[i].Price;
            totalPrice += additionsPrice;
        }

        /// <summary>
        /// Used to set a string of all additions
        /// </summary>
        private void SetAdditionsDescription()
        {
            for (int i = 0; i < additions.Count; i++)
                additionsDescription += additions[i].Addtion + ", ";
        }

        /// <summary>
        /// Used to get room price for room over a given timespan
        /// </summary>
        public string GetRoomPrice(int days)
        {
            return GetTimespanPrice(roomPrice, days);
        }

        /// <summary>
        /// Used to get total addition for room over a given timespan
        /// </summary>
        public string GetAdditionPrice(int days)
        {
            return GetTimespanPrice(additionsPrice, days);
        }

        /// <summary>
        /// Used to get total price for room over a given timespan
        /// </summary>
        public string GetTotalPrice(int days)
        {
            return GetTimespanPrice(totalPrice, days);
        }

        /// <summary>
        /// Used to calculate price over timespan
        /// </summary>
        private string GetTimespanPrice(double value, int days)
        {
            return string.Format("{0:N" + 2 + "}", (value * days));
        }
    }
}