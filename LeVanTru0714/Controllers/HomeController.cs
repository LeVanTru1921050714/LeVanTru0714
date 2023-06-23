using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeVanTru0714.Models;

namespace LeVanTru0714.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
// B1:tạo thư mục process trong model chưa file StringProcess.cs 

// using System.Text.RegularExpressions;
// namespace tênfile.Models.Process
// {
//     public class StringProcess
//     {
//         public string AutoGenerateKey ( string strInput )
//         {
//             string strResult="", numPart="", strPart="";
//             numPart=Regex.Match(strInput,@"\d+").Value;
//             strPart=Regex.Match(strInput,@"\D+").Value;
//             int intPart=(Convert.ToInt32(numPart)+1);
//             for (int i=0; i<numPart.Length - intPart.ToString().Length;i++)
//             {
//                 strPart +=0;
//             }
//             strResult=strPart+intPart;
//             return strResult;
//         }
//     }
// }
// B2: khai báo biến trong controller :  
// StringProcess mdt = new StringProcess();
// B3: đưa đoạn code sinh tự động vào chỗ controller : 
//   public IActionResult Create()
//         { 
//             var newID = "";
//             if(_context.TinhThanh.Count() == 0){
//                 // khởi tạo 1 mã mới
//                 newID = "T01";
               
//             }
//             else{
//                 // lấy ra được ID mới nhất 
//                 // OrderByDescending :  lấy giá trị giảm dần trong chuỗi
//                 var ncc = _context.TinhThanh.OrderByDescending(x=>x.MaTinhThanh).First().MaTinhThanh;
//                 // sinh mã tự động dựa trên ID mới nhất

//                 newID = mdt.AutoGenerateKey(ncc.ToString());

//             }
//             ViewBag.MaTinhThanh = newID;
           
//             // end
//             return View();
//         }
// B4 : ra phần view của đối tượng được code sinh tự động vào phần create chỉnh thêm code <div class="form-group">
//                 <label asp-for="MaTinhThanh" class="control-label"></label>
//                 <input asp-for="MaTinhThanh" class="form-control"  value="@ViewBag.MaTinhThanh" readonly />
//                 <span asp-validation-for="TenTinhThanh" class="text-danger"></span>
//             </div>
// và phần index để hiển thị dữ liệu 
