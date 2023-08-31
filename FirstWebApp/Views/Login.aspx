﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FirstWebApp.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />
</head>

<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">

        </div>


        <div class="row">
            <div class="col-md-4">


            </div>

            <div class="col-md-4">


                <form id="form1" runat="server">
                    <div class="row"> 
                        <div class="col-md-4"></div>
                        <div class="col-md-8">
                            <img src="../Assets/Images/shopping-cart.png" class="align-content-center" width="100" height="100"/>
                        </div>
                    </div>

                    <div class="mt-3">
                        <label for="" class="form-label">UserName</label>
                        <input type="email" placeholder="Email..." autocomplete="off" runat="server" class="form-control" id="UNameTb"/>
                    </div>

                    <div class="mt-3">
                        <label for="" class="form-label">Password</label>
                        <input type="text" placeholder=" Password" autocomplete="off" runat="server" class="form-control" id="UPassTb"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label><br />
                        <asp:Button Text="Login" runat="server" class="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click"/>

                    </div>
                </form>

            </div>

            <div class="col-md-4">      
                
            </div>

        </div>
    </div>
    
</body>
</html>
