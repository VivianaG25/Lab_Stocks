/*
 * 
 * 
Lab_1 program for CECS 475
Programmer: M. Viviana G.
Date: February 17, 2024
Description: The purpose of the StockBroker class is to facilitate the management of stocks by brokers in a financial system.
This class encapsulates functionalities related to handling stock events, such as registering stock objects, processing stock value changes, 
and outputting notifications to the console and a log file
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;
using System.Threading.Tasks;

namespace Lab1_Stocks
{
    /*!NOTE!: Class StockBroker has fields broker name and a list of Stock named stocks.
    addStock method registers the Notify listener with the stock (in addition to
    adding it to the lsit of stocks held by the broker). This notify method
    outputs to the console the name, value, and the number of changes of the stock whose
    value is out of the range given the stock's notification threshold.
   */
    //----------------------------------------------------------StockBroker.cs------------------------------------------------------------------------------------------------
    public class StockBroker
    {
        public string BrokerName { get; set; }
        public List<Stock> stocks = new List<Stock>();
        public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        //readonly string docPath = @"C:\Users\Documents\CECS 475\Lab3_output.txt";
        readonly string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
       "Lab1_output.txt");
        public string titles = "Broker".PadRight(16) + "Stock".PadRight(16) +
        "Value".PadRight(16) + "Changes".PadRight(10) + "Date and Time";
        //--------------------------------------------------------------------------------
        /// <summary>
        /// The stockbroker object
        /// </summary>
        /// <param name="brokerName">The stockbroker's name</param>
        public StockBroker(string brokerName)
        {
            BrokerName = brokerName;
        }
        //---------------------------------------------------------------------------------------

        /// <summary>
        /// Adds stock objects to the stock list
        /// </summary>
        /// <param name="stock">Stock object</param>
        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
            stock.StockEvent += EventHandler;
         
        }


        /// <summary>
        /// The eventhandler that raises the event of a change
        /// </summary>
        /// <param name="sender">The sender that indicated a change</param>
        /// <param name="e">Event arguments</param>
        async void EventHandler(Object sender, EventArgs e)
        {
            try
            { //LOCK Mechanism

                myLock.EnterWriteLock();
                Stock newStock = (Stock)sender;
               DateTime date1 = DateTime.Now;

                //string statement;
                //!NOTE!: Check out C#events, pg.4
                // Display the output to the console windows

                string stockLine = BrokerName.PadRight(16)
                    + newStock.StockName.PadRight(16)
                    + newStock.CurrentValue.ToString().PadRight(16) 
                    + newStock.NumChanges.ToString().PadRight(10) 
                    + date1.ToString().PadRight(10);
               
                    Console.WriteLine(stockLine);



                //Display the output to the file

                using (StreamWriter outputFile = File.AppendText(destPath))
                //using (StreamWriter outputFile = new StreamWriter(destPath, false))
                {
                    outputFile.WriteLine(stockLine);
                }
                //RELEASE the lock
                myLock.ExitWriteLock();
              
            }
            finally {

            }
           
        }

    }

}