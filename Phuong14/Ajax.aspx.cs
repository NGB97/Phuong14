using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data;

public partial class Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string action = Request.QueryString["Action"].Trim();
            switch (action)
            {
                case "PrinfKhaiSinh":
                    PrinfKhaiSinh(); break;

            }
        }
        catch { }
    }

    private void PrinfKhaiSinh()
    {
        string sqlKhaiSinh = @"select *, 'nd'=(select max(id) from tb_DetailB) from  tb_DetailB";
        DataTable data = Connect.GetTable(sqlKhaiSinh);
        if (data.Rows.Count > 0)
        {
            // em tính cho swtich case ở đây
            string html = "";
            html += @"
            <div style='width:100%'>
            <div style='font-family: 'Times New Roman', Times, serif; font-size: 13px; text-align: left; width: 842px; margin-top: -10px; margin-left: -20px;'>
            <div style='margin-top: 0; margin-left: 20px'>";
            /*Form đăng kí khai sinh*/
            html += @"
            <div style='page-break-before:always'>
            <form>
                <div class='text-center'>
                    <h3 class='title'> CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM </h3>
                    <h3 class='sub-title line-title'> Độc lập - Tự do - Hạnh phúc </h3>
                    <h3 class='title margin-bottom'>TỜ KHAI ĐĂNG KÝ KHAI SINH</h3>
                </div>
                <p class='text-center'>Kính gửi: UBND phường 14, quận Gò Vấp, thành phố Hồ Chí Minh</p>
                <div>
                    <p class='tieude'>Họ, chữ đệm, tên người yêu cầu:
                        <span class='ten'>" + data.Rows[0]["NYC_HoTen"].ToString() + @"<span>
                    </p>
                    <p>CMND/CCCD số:
                        <span class='gt'>" + data.Rows[0]["NYC_SoGT"].ToString() + @"</span>
                    </p>
                    <p>Ngày cấp:
                        <span class='gt'>" + DateTime.Parse(data.Rows[0]["NYC_NgayCap"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        <span class='ttgiua'>Nơi cấp:
                            <span class='gt'>" + data.Rows[0]["NYC_NoiCap"].ToString() + @"</span>
                        </span>
                    </p>
                    <p>Nơi cư trú:
                        <span class='gt'>" + data.Rows[0]["NYC_SoNhaDuong"].ToString() + @", " + data.Rows[0]["NYC_PhuongXa"].ToString() + @", " + data.Rows[0]["NYC_QuanHuyen"].ToString() + @", " + data.Rows[0]["NYC_TinhTP"].ToString() + @"</span>
                    </p>
                    <p>Quan hệ với trẻ được làm khai sinh:
                        <span class='gt'>" + data.Rows[0]["NYC_QuanHe"].ToString() + @"</span>
                    </p>
                    <p><b>Đề nghị cơ quan đăng ký khai sinh cho người dưới đây:</b></p>
                    <p class='tieude'>Họ, chữ đệm, tên:
                        <span class=' gt ten'>" + data.Rows[0]["TTT_HoTen"].ToString() + @"<span>
                    </p>
                    <p>Ngày,tháng,năm sinh:
                        <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTT_NgaySinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                    </p>
                    <p>Bằng chữ:
                        <span class='gt'>Ngày mười hai, tháng sáu, năm hai nghìn không trăm mười chín</span>
                    </p>
                    <p>Nơi sinh:
                        <span class='gt'>" + data.Rows[0]["TTT_TenCSYT"].ToString() + @", " + data.Rows[0]["TTT_TinhTP"].ToString() + @"</span>
                    </p>
                    <p>Giới tính:
                        <span class='gt'>" + data.Rows[0]["TTT_GioiTinh"].ToString() + @"  </span>
                        <span class='padd'>Dân tộc:
                            <span class='gt'>" + data.Rows[0]["TTT_DanToc"].ToString() + @"</span>
                            <span class='padd'>Quốc tịch:
                                <span class='gt'>" + data.Rows[0]["TTT_QuocGia"].ToString() + @"</span>
                            </span>
                        </span>
                    </p>
                    <p>Quê quán:
                        <span class='gt'>" + data.Rows[0]["TTT_SoNhaDuong_QQ"].ToString() + @"," + data.Rows[0]["TTT_PhuongXa_QQ"].ToString() + @"," + data.Rows[0]["TTT_QuanHuyen_QQ"].ToString() + @"," + data.Rows[0]["TTT_TinhTP_QQ"].ToString() + @"</span>
                    </p>
                </div>
                <div>
                    <p class='tieude'>Họ, chữ đệm, tên người mẹ:
                        <span class='ten'>" + data.Rows[0]["TTM_HoTen"].ToString() + @"<span>
                    </p>
                    <p>Năm sinh:
                        <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTM_NamSinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        <span class='padd'>Dân tộc:
                            <span class='gt'>" + data.Rows[0]["TTM_DanToc"].ToString() + @"</span>
                            <span class='padd'>Quốc tịch:
                                <span class='gt'>" + data.Rows[0]["TTM_QuocTich"].ToString() + @"</span>
                            </span>
                        </span>
                    </p>
                    <p>Quê quán:
                        <span class='gt'>" + data.Rows[0]["TTM_SoNhaDuong"].ToString() + @"," + data.Rows[0]["TTM_PhuongXa"].ToString() + @"," + data.Rows[0]["TTM_QuanHuyen"].ToString() + @"," + data.Rows[0]["TTM_TinhTP"].ToString() + @"</span>
                    </p>
                </div>
                <div>
                    <p class='tieude'>Họ, chữ đệm, tên người cha:
                        <span class='ten'>" + data.Rows[0]["TTC_HoTen"].ToString() + @"<span>
                    </p>
                    <p>Năm sinh:
                        <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTC_NamSinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        <span class='padd'>Dân tộc:
                            <span class='gt'>" + data.Rows[0]["TTC_DanToc"].ToString() + @"</span>
                            <span class='padd'>Quốc tịch:
                                <span class='gt'>" + data.Rows[0]["TTC_QuocTich"].ToString() + @"span>
                            </span>
                        </span>
                    </p>
                    <p>Quê quán:
                        <span class='gt'>" + data.Rows[0]["TTC_SoNhaDuong"].ToString() + @"," + data.Rows[0]["TTC_PhuongXa"].ToString() + @"," + data.Rows[0]["TTC_QuanHuyen"].ToString() + @"," + data.Rows[0]["TTC_TinhTP"].ToString() + @"</span>
                    </p>
                </div>
                <p class='camdoan'>Tôi cam đoan nội dung đề nghị đăng ký khai sinh trên đây là đúng sự thật, được sự thỏa thuận nhất trí của các bên liên quan theo quy định pháp luật.</p>
                <p>Tôi chịu hoàn toàn trách nhiệm trước pháp luật về nội dung cam đoan của mình.</p>
                <p class='canphai'>Phường 14,ngày&nbsp;
                    <span>" + DateTime.Now.Day.ToString() + @"&nbsp;
                        <span>tháng&nbsp;
                            <span>" + DateTime.Now.Month.ToString() + @"&nbsp;
                                <span>năm&nbsp;
                                    <span>" + DateTime.Now.Year.ToString() + @"
                                    </span>
                                </span>
                            </span>
                        </span>
                    </span>
                </p>
                <p class='kyten'><b> Người yêu cầu </b></p><br><br>
                <p class='Tenkyten'><b>" + data.Rows[0]["NYC_HoTen"].ToString() + @"</b></p>
            </form>
            </div>
           ";

            /*Form Cấp bản sao*/
        html += @"
        <div style='page-break-before:always'>
        <form>
                <div class='text-center'>
                    <h3 class='title'> CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM </h3>
                    <h3 class='sub-title line-title'> Độc lập - Tự do - Hạnh phúc </h3>
                    <h3 class='title margin-bottom'>TỜ KHAI CẤP BẢN SAO TRÍCH LỤC HỘ TỊCH</h3>
                </div>
                <p class='kg'>Kính gửi: UBND phường 14, quận Gò Vấp, thành phố Hồ Chí Minh</p>
                <p class='tieude'>Họ, chữ đệm, tên người yêu cầu:
                    <span class='gt ten'>" + data.Rows[0]["NYC_HoTen"].ToString() + @"<span>
                </p>
                <p>CMND/CCCD số:
                    <span class='gt'>" + data.Rows[0]["NYC_SoGT"].ToString() + @"</span>
                </p>
                <p>Ngày cấp:
                    <span class='gt'>" + DateTime.Parse(data.Rows[0]["NYC_NgayCap"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                    <span class='ttgiua'>Nơi cấp:
                        <span class='gt'>" + data.Rows[0]["NYC_NoiCap"].ToString() + @"</span>
                    </span>
                </p>
                <p>Nơi cư trú:
                    <span class='gt'>" + data.Rows[0]["NYC_SoNhaDuong"].ToString() + @", " + data.Rows[0]["NYC_PhuongXa"].ToString() + @", " + data.Rows[0]["NYC_QuanHuyen"].ToString() + @", " + data.Rows[0]["NYC_TinhTP"].ToString() + @"</span>
                </p>
                <p>Quan hệ với trẻ được làm khai sinh:
                    <span class='gt'>" + data.Rows[0]["NYC_QuanHe"].ToString() + @"</span>
                </p>
                <p><b>Đề nghị cơ quan cấp bản sao trích lục Giấy Khai Sinh cho người có tên dưới đây:</b></p>
                <p>Họ, chữ đệm, tên:
                    <span class='ten'>" + data.Rows[0]["TTT_HoTen"].ToString() + @"<span>
                </p>
                <p>Ngày,tháng,năm sinh:
                    <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTT_NgaySinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                </p>
                <p>Giới tính:
                    <span class='gt'>" + data.Rows[0]["TTT_GioiTinh"].ToString() + @" </span>
                    <span class='padd'>Dân tộc:
                        <span class='gt'>" + data.Rows[0]["TTT_DanToc"].ToString() + @"</span>
                        <span class='padd'>Quốc tịch:
                            <span class='gt'>" + data.Rows[0]["TTT_QuocGia"].ToString() + @"</span>
                        </span>
                    </span>
                </p>
                <p>Nơi cư trú:
                    <span class='gt'>" + data.Rows[0]["TTT_PhuongXa"].ToString() + @"," + data.Rows[0]["TTT_QuanHuyen"].ToString() + @"," + data.Rows[0]["TTT_TinhTP"].ToString() + @"</span>
                </p>
                <p>Giấy tớ tùy thân:
                    <span class='gt'>....</span>
                </p>
                <p>Số định danh cá nhân:
                    <span class='gt'>....</span>
                </p>
                <p>Đã đăng kí khai sinh tại:
                    <span class='gt'> Ủy ban nhân dân phường 14, quận Gò Vấp, thành phố Hồ Chí Min </span>
                </p>
                <p>Theo giấy khai sinh số:
                    <span class='gt ten'>" + data.Rows[0]["id"].ToString() + @"</span>
                </p>
                <p>Số lượng bản sao đề nghị cấp:
                    <span class='gt'> </span>bản sao
                </p>
                <p class='camdoan'>Tôi cam đoan nội dung đề nghị đăng ký khai sinh trên đây là đúng sự thật, được sự thỏa thuận nhất trí của các bên liên quan theo quy định pháp luật.</p>
                <p>Tôi chịu hoàn toàn trách nhiệm trước pháp luật về nội dung cam đoan của mình.</p>
                <p class='canphai'>Phường 14,ngày&nbsp;
             <span>" + DateTime.Now.Day.ToString() + @"&nbsp;
                   <span>tháng&nbsp;
                 <span>" + DateTime.Now.Month.ToString() + @"&nbsp;
                   <span>năm&nbsp;
                     <span>" + DateTime.Now.Year.ToString() + @"
                     </span>
                   </span>
                 </span>
               </span>
             </span>
           </p>
        <p class='kyten'><b> Người yêu cầu </b></p><br><br><br>
        <p class='Tenkyten'><b>" + data.Rows[0]["NYC_HoTen"].ToString() + @"</b></p>
        </form> 
        </div>            
        ";
        /*Bảo hiểm*/
            html += @"
        <div style='page-break-before:always'>
        <form>
            <div>
                <div class='flex justify-content-between'>
                    <div class='item'>
                        <h4 class='line-title'></h4>
                    </div>
                    <div class='item text-center'>
                        <h4 class='title size-small'> Mẫu TK1-TS </h4>
                        <p class='sub-title size-small'>(Ban hành kèm theo QĐ số: 595/QĐ-BHXH ngày 14/4/2017 của BHXH Việt Nam)</p>
                    </div>
                </div>
            </div>
            <div>
                <div class='flex justify-content-between'>
                    <div class='item'>
                        <h4 class='line-title'>BẢO HIỂM XÃ HỘI VIỆT NAM</h4>
                    </div>
                    <div class='item text-center'>
                        <h4 class='title'> CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM </h4>
                        <h4 class='sub-title line-title'> Độc lập - Tự do - Hạnh phúc </h4>
                    </div>
                </div>
            </div>
            <h4>TỜ KHAI</h4>
            <h4 class='title sub-title'>THAM GIA, ĐIỀU CHỈNH THÔNG TIN BẢO HIỂM XÃ HỘI, BẢO HIỂM Y TẾ</h4>
            <p class='text-center'>Kính gửi: UBND phường 14, quận Gò Vấp, thành phố Hồ Chí Minh</p>
            <p class='tieude'>I.Phần kê khai bắt buộc:
                <p>Họ, chữ đệm, tên:
                    <span class='gt ten'>" + data.Rows[0]["TTT_HoTen"].ToString() + @"<span>
                </p>
                <p>Ngày, tháng, năm sinh:
                    <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTT_NgaySinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                    <span class='ttgiua'>Giới tính:
                        <span class='gt'>" + data.Rows[0]["TTT_GioiTinh"].ToString() + @"</span>
                    </span>
                </p>
                <p>Quốc tịch:
                    <span class='gt'>" + data.Rows[0]["TTT_QuocGia_NoiSinh"].ToString() + @"</span>
                    <span class='ttgiua'> Dân tộc:
                        <span class='gt'>" + data.Rows[0]["TTT_GioiTinh"].ToString() + @"</span>
                    </span>
                </p>
                <p>Nơi đăng ký giấy khai sinh:
                    <span class='padd'> UBND phường 14,quận Gò vấp, TP.HCM</span> </p>
                    <p class='tieude'> Địa chỉ nhận hồ sơ:</p>
                    <p>Số nhà, đường phố, thôn xóm:
                        <span class='gt'>" + data.Rows[0]["NYC_SoNhaDuong"].ToString() + @"</span>
                        <span class='padd'>Xã(phường,thị trấn):
                            <span class='gt'>" + data.Rows[0]["NYC_PhuongXa"].ToString() + @"</span>
                        </span>
                    </p>
                    <p>Huyện (quận, thị xã, Tp thuộc tỉnh):
                        <span class='gt'>" + data.Rows[0]["NYC_QuanHuyen"].ToString() + @"</span>
                        <span class='ttgiua'>Tỉnh/Thành phố:
                            <span class='gt'>" + data.Rows[0]["NYC_TinhTP"].ToString() + @"</span>
                        </span>
                    </p>
                    <p>Họ tên cha/ mẹ/ người giám hộ (đối với trẻ em dưới 6 tuổi):
                        <span class='ten'>" + data.Rows[0]["TTC_HoTen"].ToString() + @"
                    </p>
                    <p class='tieude'>II. Phần kê khai chung :
                        <p>Mã số BHXH(đã cấp):
                            <span class='gt'>...</span>
                            <span class='ttgiua'>Số điện thoại liên hệ:
                                <span class='gt'>" + data.Rows[0]["NYC_SDT"].ToString() + @"</span>
                            </span>
                        </p>
                        <p>Số CMND:
                            <span class='gt'>" + data.Rows[0]["NYC_SoGT"].ToString() + @"</span>
                            <span class='padd'>Mã số hộ gia đình (đã cấp):
                            <span class='gt'>...</span>
                            </span>
                        </p>
                        <p>Nơi sinh:
                           <span class='gt'>" + data.Rows[0]["TTT_TenCSYT"].ToString() + @"</span>
                           <span >Nơi đăng kí khám chữa bệnh ban đầu:
                                <span class='gt'>" + data.Rows[0]["TTT_KCB"].ToString() + @"</span>
                        </span>
                        </p> 
                        <p>Mức tiền đóng:
                            <span class='gt'>....</span>đồng
                            <span class='padd'>Phương thức đóng:
                                <span class='gt'>....</span>
                            </span>
                        </p>
                        <p>Nội dung thay đổi, yêu cầu:
                            <span class='gt'>.....</span>
                        </p>
                        <p>Hồ sơ kèm theo (nếu có):
                            <span class='gt'>......</span>
                        </p>
            <div>
                <div class='flex justify-content-between'>
                    <div class='item'>
                         <p class='item title text-center sub-title'>XÁC NHẬN CỦA ĐƠN VỊ</p>
                         <p class='title'>(chỉ áp dụng đối với người lao động thay đổi</p>
                         <p class='text-center title sub-title'> họ, tên đệm, tên; ngày, tháng, năm sinh)</p>      
                    </div>
                    <div class='item'>
                         <p class='item title text-center sub-title'>Tôi cam đoan những nội dung kê khai là đúng và chịu </p>
                         <p class='title'>trách nhiệm trước pháp luật về những nội dung đã kê khai.</p>
                         <p class='title sub-title text-center'>Phường 14, ngày&nbsp;
                          <span>" + DateTime.Now.Day.ToString() + @"&nbsp;
                            <span>tháng&nbsp;
                                <span>" + DateTime.Now.Month.ToString() + @"&nbsp;
                                    <span>năm&nbsp;
                                         <span>" + DateTime.Now.Year.ToString() + @"
                                        </span>
                                    </span>
                                </span>
                           </span>
                        </p>
                        <p class='kyten'><b> Người yêu cầu </b></p><br><br><br>
                        <p class='Tenkyten'><b>" + data.Rows[0]["NYC_HoTen"].ToString() + @"</b></p>
                    </div>
                </div>
            </div>
            </div>
       <div>
        </form>
        </div>
         ";


        /*Y tế*/
        html += @"
        <div style='page-break-before:always'>
        <form>
                <h3 class='title text-center'>PHIẾU CUNG CẤP THÔNG TIN TRẺ SINH TRONG NĂM</h3>
                <div class='flex justify-content-between margin-bottom'>
                    <div class='item'>
                        <p>Họ tên trẻ:
                            <span class='gt'>" + data.Rows[0]["TTT_HoTen"].ToString() + @"</span>
                        </p>
                        <p>Ngày sinh:
                            <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTT_NgaySinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        </p>
                        <p>Nơi sinh:
                            <span class='gt'>" + data.Rows[0]["TTT_TenCSYT"].ToString() + @"</span>
                        </p>
                        <p>Kiểu sinh:
                            <span class='gt'>" + data.Rows[0]["TTT_KieuSinh"].ToString() + @"</span>
                        </p>
                        <p>Họ tên mẹ:
                            <span class='gt'>" + data.Rows[0]["TTM_HoTen"].ToString() + @"</span>
                        </p>
                        <p>Họ tên cha:
                            <span class='gt'>" + data.Rows[0]["TTC_HoTen"].ToString() + @"</span>
                        </p>
                    </div>
                    <div class='item'>
                        <p>Giới tính:
                            <span class='gt'>" + data.Rows[0]["TTT_GioiTinh"].ToString() + @"</span>
                        </p>
                        <p>Con thứ:
                            <span class='gt'>" + data.Rows[0]["TTT_ConThu"].ToString() + @"</span>
                        </p>
                        <p>
                            <span class='gt'></span>
                        </p>
                        <p>Cân nặng:
                            <span class='gt'>" + data.Rows[0]["TTT_CanNang"].ToString() + @"</span>gram
                        </p>
                        <p>Năm sinh:
                            <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTM_NamSinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        </p>
                        <p>Năm sinh:
                            <span class='gt'>" + DateTime.Parse(data.Rows[0]["TTC_NamSinh"].ToString()).ToString("dd/MM/yyyy") + @"</span>
                        </p>
                    </div>
                    <div class='item'>
                        <p></p>
                    </div>
                </div>
                <p>Địa chỉ thường trú:
                    <span class='gt'>" + data.Rows[0]["TTT_SoNhaDuong_QQ"].ToString() + @", " + data.Rows[0]["TTT_PhuongXa_QQ"].ToString() + @", " + data.Rows[0]["TTT_QuanHuyen_QQ"].ToString() + @", " + data.Rows[0]["TTT_TinhTP_QQ"].ToString() + @"</span>
                </p>
                <p>Chỗ ở thực tế hiện nay:
                    <span class='gt'>" + data.Rows[0]["NYC_SoNhaDuong"].ToString() + @", " + data.Rows[0]["NYC_PhuongXa"].ToString() + @", " + data.Rows[0]["NYC_QuanHuyen"].ToString() + @", " + data.Rows[0]["NYC_TinhTP"].ToString() + @"</span>
                </p>
                <p>Số điện thoại liên hệ:
                    <span class='gt'>" + data.Rows[0]["NYC_SDT"].ToString() + @"</span>
                </p>
                <p class='text-right padd-right'><b>Người kê khai</b></p>
                <p class='text-right padd-right1 padd'><b>" + data.Rows[0]["NYC_HoTen"].ToString() + @"</b>
            </form>
        </div>
        ";
       
        html += @" </div></div></div>";
            Response.Write(html);
        }
    }
}