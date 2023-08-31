<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="FirstWebApp.Views.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="col">
                <h3 class="text-center">Seller</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">

                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Name</label>;
                    <input type="text" placeholder="Name" autocomplete="off" class="form-control" runat="server" id="SelNameTb" />

                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Email</label>;
                    <input type="text" placeholder="Seller's Email" autocomplete="off" class="form-control" runat="server" id="SelEmailTb" />

                </div>


                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Phone</label>;
                    <input type="text" placeholder="Phone Number" autocomplete="off" class="form-control" runat="server" id="SelPhoneTb" />

                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Password</label>;
                    <input type="text" placeholder="Password" autocomplete="off" class="form-control" runat="server" id="SelAddressTb" />
                </div>
                
                <div class="row">
                    <%-- this show error--%>
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>
                    <div class="col d-grid">
                        <asp:Button Text="Update" runat="server" ID="UpdateBtn" class="btn-warning btn-block btn" OnClick="UpdateBtn_Click" />
                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Save" runat="server" ID="SaveBtn" class="btn-success btn-block btn" OnClick="SaveBtn_Click" />
                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Delete" runat="server" ID="DeleteBtn" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" />
                    </div>

                </div>

            </div>

            <div class="col-md-8">
                <asp:GridView ID="SellerList" runat="server" class="table" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" Width="844px" AutoGenerateSelectButton="True" Height="182px">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#51001b" Font-Bold="True" ForeColor="Wheat" />
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
</asp:Content>
