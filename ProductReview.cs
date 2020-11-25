using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReviewManagement
{
    /// <summary>
    /// POCO Class
    /// </summary>
    public class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool isLike { get; set; }
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"ProductID: - {ProductID}  UserID: - { UserID} Rating:- {Rating} Review:- { Review}  isLike:- { isLike}";
        }
    }
}
