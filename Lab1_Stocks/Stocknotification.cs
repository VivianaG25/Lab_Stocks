/* 
 *  
 *  
This is the first Lab program for CECS 475
Programmer: M. Viviana G
Date: February 17, 2024
Description: The purpose of the StockNotification class is to define a custom event arguments class specifically tailored for stock notifications. 
This class inherits from EventArgs, providing a standardized way to pass information about stock value changes between the Stock class 
(which raises events when stock values change) and the StockBroker class (which handles these events).
 * 
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1_Stocks
{
    public class StockNotification : EventArgs
    {
        public string StockName { get; set; }
        public int CurrentValue { get; set; }
        public int NumChanges { get; set; }
        /// <summary>
        /// Stock notification attributes that are set and changed
        /// </summary>
        /// <param name="stockName">Name of stock</param>
        /// <param name="currentValue">Current vallue of the stock</param>
        /// <param name="numChanges">Number of changes the stock goes through</param>
        public StockNotification(string stockName, int currentValue, int numChanges)
        {
    // !NOTE!: Fill in below of what the notification will do using the comments above
        this.StockName = stockName;
        this.CurrentValue = currentValue;
        this.NumChanges = numChanges;
        }
    }
}
