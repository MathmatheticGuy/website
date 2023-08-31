<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="FirstWebApp.Views.Admin.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
       
        <div class="row">
            <div class="col">

                <h2 class="text-center">Manage Books</h2>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">

                <div class="mb-3">
                     <label for="" class="form-label text-success">Books Title</label>
                     <input type="text" placeholder="Title" id="BNameTb" runat="server" autocomplete="off" class="form-control" />
                 </div>

                 <div class="mb-3">
                     <label for="" class="form-label text-success">Books Author</label>
                     <asp:DropDownList id="BAuthTb" runat="server" class="form-control"></asp:DropDownList>
                 </div>

                 <div class="mb-3">
                     <label for="" class="form-label text-success">Categories</label>
                     <asp:DropDownList id="BCateCb" runat="server" class="form-control"></asp:DropDownList>
                 </div>

                 <div class="mb-3">
                     <label for="" class="form-label text-success">Price</label>
                     <input type="text" id="BPriceTb" placeholder="Price" runat="server" autocomplete="off" class="form-control" />
                 </div>

                 <div class="mb-3">
                    <label for="" class="form-label text-success">Quantity</label> 
                     <input type="text" placeholder="Quantity" id="BQuanTb" runat="server" autocomplete="off" class="form-control" />
                </div>

                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>
                    <div class="col d-grid"> <asp:Button Text="Update" runat="server" ID="UpdateBtn" class="btn-warning btn-block btn" OnClick="UpdateBtn_Click" /> </div>
                    <div class="col d-grid"> <asp:Button Text="Save" runat="server" ID="SaveBtn" class="btn-success btn-block btn" OnClick="SaveBtn_Click" /> </div>
                    <div class="col d-grid"> <asp:Button Text="Delete" runat="server" ID="DeleteBtn" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" /> </div>
                </div>

            </div>

            
            <div class="col-md-8">
                <asp:GridView ID="BooksList" runat="server" class="table" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" Width="844px" AutoGenerateSelectButton="True" Height="207px">
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

