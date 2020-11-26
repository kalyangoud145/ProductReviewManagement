using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// Retrive Top  three records with higest ratings
        /// </summary>
        /// <param name="listProductReview">The list product review.</param>
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            // Prints top three records with highest ratings
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
        /// <summary>
        /// Prints the Selected  records for given condition
        /// </summary>
        /// <param name="listProductReview">The list product review.</param>
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 4
                               || productReview.ProductID == 9)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
        /// <summary>
        /// Retrieves the count of record existing for each product id
        /// </summary>
        /// <param name="listProductReview">The list product review.</param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product ID: " + list.ProductID + " " + "Count: " + list.Count);
            }
        }
        /// <summary>
        /// Retrive product id and review from the list
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               select new { productReview.ProductID, productReview.Review };
            // Prints the data from the recorded data
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product id: "+list.ProductID + " " +"Review: "+ list.Review);
            }
        }
        /// <summary>
        /// Skip top five records from the list and print remaining
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                select productReview).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
    }
}
