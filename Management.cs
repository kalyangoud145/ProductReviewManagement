﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public Management()
        {
            //Creating Columns of the DataTable
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));

            //Inserting Data into the Table
            dataTable.Rows.Add(1, 1, 2d, "Good", true);
            dataTable.Rows.Add(2, 1, 4d, "Good", true);
            dataTable.Rows.Add(3, 1, 5d, "Good", true);
            dataTable.Rows.Add(4, 1, 6d, "Good", false);
            dataTable.Rows.Add(5, 1, 2d, "nice", true);
            dataTable.Rows.Add(6, 1, 1d, "bas", true);
            dataTable.Rows.Add(8, 1, 1d, "Good", false);
            dataTable.Rows.Add(8, 1, 9d, "nice", true);
            dataTable.Rows.Add(2, 1, 10d, "nice", true);
            dataTable.Rows.Add(10, 1, 8d, "nice", true);
            dataTable.Rows.Add(11, 1, 3d, "nice", true);
            dataTable.Rows.Add(12, 10, 5d, "Okay", true);
            dataTable.Rows.Add(13, 10, 8d, "Nice", true);
            dataTable.Rows.Add(11, 10, 2d, "Bad", false);
            dataTable.Rows.Add(15, 10, 9d, "Nice", true);
            dataTable.Rows.Add(14, 10, 7d, "Good", true);
            dataTable.Rows.Add(16, 10, 9d, "Nice", true);
            dataTable.Rows.Add(17, 10, 9d, "Nice", true);
            dataTable.Rows.Add(18, 10, 9d, "Nice", true);
            dataTable.Rows.Add(19, 10, 9d, "Nice", true);
            dataTable.Rows.Add(20, 10, 9d, "Nice", true);
        }
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
                Console.WriteLine("Product id: " + list.ProductID + " " + "Review: " + list.Review);
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
        /// <summary>
        /// Retrive the product id and review from the list
        /// </summary>
        /// <param name="listProductReview">The list product review.</param>
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProductID, x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product ID: " + list.ProductID + " " + "Count: " + list.Review);
            }
        }
        /// <summary>
        /// Retrieves all the  records in the data table whose islike value is true
        /// </summary>
        public void RetrieveTrueIsLike()
        {
            var Data = from reviews in dataTable.AsEnumerable()
                       where reviews.Field<bool>("isLike").Equals(true)
                       select reviews;
            foreach (var dataItem in Data)
            {
                Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
            }
        }
        /// <summary>
        /// Retive the average rating of each product id
        /// </summary>
        public void AverageRatingByProductID()
        {
            var Data = dataTable.AsEnumerable()
                        .GroupBy(x => x.Field<int>("ProductID"))
                        .Select(x => new { ProductID = x.Key, Average = x.Average(p => p.Field<double>("Rating")) });
            foreach (var dataItem in Data)
            {
                Console.WriteLine("Product Id: " + dataItem.ProductID + " " + "Average: " + dataItem.Average);
            }
        }
        /// <summary>
        /// Retrive all records whose Reviews  with the nice message.
        /// </summary>
        public void ReviewsWithNiceMessage()
        {
            var Data = dataTable.AsEnumerable()
                        .Where(x => x.Field<string>("Review").Contains("Nice", StringComparison.OrdinalIgnoreCase));
            foreach (var dataItem in Data)
            {
                {
                    Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
                }
            }
        }
        /// <summary>
        /// Retrive all records of given product id order by rating
        /// </summary>
        public void OrderByRatingOnCondition()
        {
            var Data = dataTable.AsEnumerable()
                        .Where(x => x.Field<int>("UserID") == 10)
                        .OrderBy(x => x.Field<double>("Rating"));
            foreach (var dataItem in Data)
            {
                {
                    Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
                }
            }
        }
    }
}
