<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fatnisse.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Fatnisse</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/landing-page.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

    <style>
        .information{
            color:black;
            text-align:left;
            text-decoration:underline;
        }

        .field{
            color:black;
            text-align:left;
            float:left;
        }

         .roundCorners {
            border-radius: 5px;
            border: 2px solid rgba(102, 102, 102, 1);
            padding: 8px;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Navigation -->
            <nav class="navbar navbar-default navbar-fixed-top topnav" role="navigation">
                <div class="container topnav">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand topnav" href="Default.aspx">Fatnisse</a>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav navbar-right">
                            <li id="navbar" runat="server">
                                <a id="btnLogin" runat="server" href="Login.aspx">Login</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>
            <!-- Header -->
            <div class="intro-header" style="background: none !important;">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div>
                                <!-- USER INFORMATION -->
                                <h1 class="information">User information</h1>
                                <asp:HiddenField ID="hdnID" Value="" runat="server" />
                                <h5 class="field">Email</h5><br /><br />
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <h5 class="field">Phone</h5><br /><br />
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <h5 class="field">Firstname</h5><br /><br />
                                <asp:TextBox ID="txtFirstname" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <h5 class="field">Lastname</h5><br /><br />
                                <asp:TextBox ID="txtLastname" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="btn-success roundCorners" OnClick="btnSave_Click" />

                                <h1 class="information">Change password</h1>
                                <h5 class="field">Old Password</h5><br /><br />
                                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <h5 class="field">New Password</h5><br /><br />
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="field roundCorners" Text=""></asp:TextBox><br /><br />
                                <asp:Button ID="btnChangePassword" Text="Save" runat="server" CssClass="btn-success roundCorners" OnClick="btnChangePassword_Click" />
                                <!-- USER INFORMATION END -->

                                <h1 class="information">Subscription</h1>


                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.container -->
            </div>
            <!-- /.intro-header -->
            <!-- Footer -->
            <footer>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <ul class="list-inline">
                                <li>
                                    <a href="Default.aspx">Home</a>
                                </li>
                            </ul>
                            <p class="copyright text-muted small">Copyright &copy; Fatnisse 2017. All Rights Reserved</p>
                        </div>
                    </div>
                </div>
            </footer>

            <!-- jQuery -->
            <script src="js/jquery.js"></script>

            <!-- Bootstrap Core JavaScript -->
            <script src="js/bootstrap.min.js"></script>
        </div>
    </form>
</body>
</html>
