namespace Ecommerce.Controllers
{
    public class HttpPostedFileBase
    {
        internal readonly int ContentLength;
        internal readonly String? FileName;

        internal void SaveAs(string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}