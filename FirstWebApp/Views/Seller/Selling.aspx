<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Selling.aspx.cs" Inherits="FirstWebApp.Views.Seller.Selling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        <%--When a Book is sold, the Stock is refreshed--%>
        function PrintBill() {
            var PGrid = document.getElementById('<%=BillList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width=1024, height=768, tollbar=1, scrollbars=1, status=0, resizable=1')
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">


    <div class="container-fluid">
        <div class="row">
        </div>

        <div class="row">
            <div class="col-md-5">


                <h3 class="text-center" style="color:sandybrown">Book Detail</h3>
                
                <%-- First --%>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Book Name</label>
                            <input type="text" placeholder="Email..." autocomplete="off" runat="server" class="form-control" id="BNameTb"/>
                        </div>
                    </div>


                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Book Price</label>    
                            <input type="text" placeholder="Price..." autocomplete="off" runat="server" class="form-control" id="BPriceTb" />
                        </div>
                    </div>
                </div>

                <%-- Second --%>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Book Quantity</label>
                            <input type="text" placeholder="Quantity..." autocomplete="off" runat="server" class="form-control" id="BQtyTb"/>
                        </div>
                    </div>


                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Billing Date</label>
                            <input type="date" runat="server" class="form-control" id="DateTb" />
                        </div>
                    </div>

                    <%-- BUTTON --%>
                    <div class="row mt-3 mb-3">
                        <div class="col d-grid">
                            <div class="d-grid">
                                 <asp:Label runat="server" ID="Label1" CssClass="text-danger text-center"></asp:Label>
                                <asp:Button Text="Print" runat="server" ID="AddToBillBtn" class="btn-warning btn-block btn" OnClick="AddToBillBtn_Click" />
                            </div>
                        </div>
                    </div>

                </div>

                <div class="row mt-5">
                    <h3 class="text-center" style="color: sandybrown">Book List</h3>
                    <div class="col">
                        <asp:GridView ID="BooksList" runat="server" class="table" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="SlateBlue" GridLines="Vertical" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" AutoGenerateSelectButton="True">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="SaddleBrown" Font-Bold="True" ForeColor="Wheat" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#51001b" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </div>
                </div>


            </div>


            <div class="col-md-7">
                <h4 class="text-center" style="color:crimson">Client's Bill</h4>
                <div class="col">
                    
                    <asp:GridView ID="BillList" runat="server" class="table" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" AutoGenerateSelectButton="True">
                        <AlternatingRowStyle BackColor="Wheat" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="RosyBrown" Font-Bold="True" ForeColor="SlateBlue" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    
                    <div class="d-grid">
                        <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>

                        <asp:Label runat="server" ID="Discount" class="text-danger text-center" />
                        <asp:Label runat="server" ID="GrdTotalTb" class="text-danger text-center" />
                        <asp:Button Text="Print" runat="server" ID="PrintBtn" OnClientClick="PrintBill()" class="btn-warning btn-block btn" OnClick="PrintBtn_Click"/>
                    </div>

                </div>
            </div>
            

        </div>


    </div>
</asp:Content>
