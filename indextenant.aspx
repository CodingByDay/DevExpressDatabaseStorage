﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="indextenant.aspx.cs" Inherits="peptak.indextenant" %>

<%@ Register assembly="DevExpress.Dashboard.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="css/bootstrap.css" />
	<link rel="stylesheet" href="fonts/font-awesome-4.3.0/css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/all.css" />
	<link href='http://fonts.googleapis.com/css?family=Montserrat:400,700|Source+Sans+Pro:400,700,400italic,700italic' rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <div class="row">
             <webopt:bundlereference runat="server" path="~/css/graphs.css" />
<link href= "~/css/graphs.css" rel="stylesheet" runat="server" type="text/css" />
           <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
        <script>





            function onBeforeRender(sender) {
                var dashboardControl = sender.GetDashboardControl();
                // ...
                dashboardControl.registerExtension(new DevExpress.Dashboard.DashboardPanelExtension(dashboardControl));
            }
            $(document).keypress(function (e) { if (e.keyCode === 13) { e.preventDefault(); return false; } });

            $(function () {

                $(':text').bind('keydown', function (e) { //on keydown for all textboxes  

                    if (e.keyCode == 13) // if this is enter key  

                        e.preventDefault();

                });

            });

            odd = 0;
            $(document).ready(function () {
                $("#pic").click(function () {

                    odd++;
                    if (odd % 2 == 0) {
                        show();
                    } else {
                        hide();
                    }

                });

            });


            function show() {
                $('.dx-overlay-content').show();
                console.log("Show");
                $(".dx-dashboard-surface").attr('style', 'left: 250px !important');
            }


            function hide() {
                $('.dx-overlay-content').hide();
                console.log("hide");
                $(".dx-dashboard-surface").attr('style', 'left: 10px !important');

            }



            $(".dx-item dx-list-item").click(function () {


                console.log("Testi");


            });


        </script>
    
        <div class="col-sm-12">
        <div style="position: absolute; left: 80px; right: 0; top:0; bottom:30px;">
 
</div>
        </div>
    </div>
    <div class="jumbotron">
        

</div>
   
 
<div style="position: absolute; left: 0; right: 0; top:60px; bottom:0;">
    <dx:ASPxDashboard ID="ASPxDashboard3" runat="server" AllowCreateNewJsonConnection="True"  AllowExecutingCustomSql="True" AllowInspectAggregatedData="True" MobileLayoutEnabled="Auto" AllowInspectRawData="True" EnableCustomSql="True" EnableTextBoxItemEditor="True">
        <ClientSideEvents BeforeRender="onBeforeRender" />
    </dx:ASPxDashboard>
</div>

   


</asp:Content>