using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace ReviewApp.Helpers
{
    public static class ReviewHtmlHelpers
    {
        public static IHtmlContent RenderReview(this IHtmlHelper htmlHelper, string author, string message, int rating, DateTime createdAt)
        {
            var encodedAuthor = HtmlEncoder.Default.Encode(author);
            var encodedMessage = HtmlEncoder.Default.Encode(message);
            var encodedRating = HtmlEncoder.Default.Encode(rating.ToString());
            var encodedDate = HtmlEncoder.Default.Encode(createdAt.ToString("g"));

            var html = $@"
                <div class='review-item' style='border: 1px solid #ddd; padding: 10px; margin-bottom: 10px;'>
                    <strong>{encodedAuthor}</strong> <span style='color: #777;'>({encodedDate})</span><br />
                    <p>{encodedMessage}</p>
                    <span><strong>Rating:</strong> {encodedRating}/5</span>
                </div>";

            return new HtmlString(html);
        }
    }
}
