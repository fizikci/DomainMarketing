<%@ Page Language="C#" AutoEventWireup="true" Inherits="DealerSafe2.API.Staff.BasePage" %>

<%@ Import Namespace="DealerSafe2.API" %>
<%@ Import Namespace="DealerSafe2.API.Entity.ApiRelated" %>

<!DOCTYPE html>
<html data-ng-app="dealerSafeApp">
<head>
    <title>DealerSafe Staff</title>
    <link href="/Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Assets/css/font-awesome.min.css" />

    <!--link rel="stylesheet" href="/Assets/css/jquery-ui-1.10.3.full.min.css" /-->
    <link rel="stylesheet" href="/Assets/css/datepicker.css" />
    <!--link rel="stylesheet" href="/Assets/css/ui.jqgrid.css" /-->
    <link rel="stylesheet" href="/Assets/css/chosen.min.css" />
    <link rel="stylesheet" href="/Assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="/Assets/css/daterangepicker.css" />
    <!--link rel="stylesheet" href="/Assets/css/colorpicker.css" /-->

    <!--[if IE 7]>
		  <link rel="stylesheet" href="/Assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <!-- fonts -->
    <script>
        var currentApiId = '<%=Provider.CurrentApi.Id%>';
    </script>

    <link rel="stylesheet" href="/Assets/css/ace-fonts.css" />

    <!-- ace styles -->

    <link rel="stylesheet" href="/Assets/css/uncompressed/ace.css" />
    <link rel="stylesheet" href="/Assets/css/uncompressed/ace-rtl.css" />
    <link rel="stylesheet" href="/Assets/css/uncompressed/ace-skins.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="/Assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="/Assets/js/ace-extra.min.js"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="/Assets/js/html5shiv.min.js"></script>
		<script src="/Assets/js/respond.min.js"></script>
		<![endif]-->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='/Assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>

    <!--[if IE]>
        <script type="text/javascript">
         window.jQuery || document.write("<script src='/Assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
        </script>
        <![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>
    <script src="/Assets/js/bootstrap.min.js"></script>
    <!-- page specific plugin scripts -->

    <!--[if lte IE 8]>
		  <script src="/Assets/js/excanvas.min.js"></script>
		<![endif]-->
    <link href="/Assets/js/jqvmap/jqvmap.css" media="screen" rel="stylesheet" type="text/css" />

    <link href="/Assets/default.css" rel="stylesheet" />
    <script src="/Assets/js/prototype.js"></script>
</head>
<body>
    <div class="Region navbar navbar-default" id="navbar">
        <script type="text/javascript">
            try {
                ace.settings.check('navbar', 'fixed');
            } catch (e) { }
        </script>


        <div id="navbar-container" class="navbar-container">

            <div class="navbar-header pull-left">
                <a href="/Staff/Default.aspx" class="navbar-brand">
                    <small>
                        <span class="msg-photo" style="width: 50px; position: absolute; top: 6px; display: inline-block; background: white; color: #b74635; padding: 7px; font-weight: bold;">FBS</span>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; DealerSafe Staff
                    </small>
                </a>
                <!-- /.brand -->
            </div>
            <!-- /.navbar-header -->

            <div class="navbar-header pull-right" role="navigation">
                <ul class="nav ace-nav">

                    <script>
                        function notificationsController($scope, $routeParams, entityService){
                            entityService.getList('Job', 20, 0, function (res) {
                                $scope.$apply(function () {
                                    $scope.notifications = res.list;
                                    $scope.notStarted = res.list.filter(function(n) { return n.State == 'NotStarted'; }).length;
                                    $scope.processing = res.list.filter(function(n) { return n.State == 'Processing'; }).length;
                                });
                            }, 'Executer = Staff AND ExecuterId = <%=Provider.CurrentMember.Id%>', 'InsertDate desc');

                            $scope.redirectTo = function(job) {
                                location.href = '/Staff/Handlers/DoCommand.ashx?method=redirectForJob&jid=' + job.Id;
                            };
                            }
                    </script>

                    <li class="purple" ng-controller="notificationsController">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="?">
                            <i class="icon-bell-alt icon-animated-bell"></i>
                            <span class="badge badge-important" ng-show="notStarted">{{notStarted}}</span>
                        </a>
                        <ul class="pull-right dropdown-navbar navbar-pink dropdown-menu dropdown-caret dropdown-close">
                            <li class="dropdown-header">
                                <i class="icon-warning-sign"></i>
                                {{notStarted + processing}} <%=Provider.TR("Notifications") %>
                            </li>
                            <li ng-repeat="n in notifications" style="{{n.state=='notstarted'?'background-color: lightyellow;': '' }}">
                                <a ng-click="redirectTo(n)" style="white-space: initial;">
                                    <div class="clearfix">
                                        <span class="pull-left">
                                            <i ng-show="n.Icon" class="btn btn-xs no-hover btn-pink icon-{{n.Icon}}"></i>
                                            {{n.Name || n.Command}}
                                        </span>
                                        <span ng-show="n.Count" class="pull-right badge badge-info">0</span>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#"><%=Provider.TR("See all notifications") %>
                                    <i class="icon-arrow-right"></i>
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li class="light-blue">
                        <a data-toggle="dropdown" href="?" class="dropdown-toggle">
                            <img class="nav-user-photo" src="/Assets/avatars/user.jpg" />
                            <span class="user-info">
                                <small><%=Provider.TR("Welcome") %><br />
                                    <b><%=Provider.CurrentMember.FullName%></b></small>

                            </span>

                            <i class="icon-caret-down"></i>
                        </a>

                        <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                            <li><a href="#"><i class="icon-dashboard"></i><%=Provider.TR("Dashboard") %></a></li>
                            <li class="divider"></li>
                            <%
                                foreach (var api in Provider.Database.ReadList<Api>("select * from Api where Id in (select ApiId from ApiClient where ClientId = {0})", Provider.CurrentMember.ClientId))
                                {
                            %>
                            <li class='<%=api.Id==Provider.CurrentApi.Id?"active":""%>'><a href="Default.aspx?apiId=<%=api.Id%>"><i class="icon-cog"></i><%=api.Name%></a></li>
                            <%
                                }
                            %>
                            <li class="divider"></li>
                            <li><a href="/Staff/Handlers/DoLogin.ashx?logout=1"><i class="icon-off"></i><%=Provider.TR("Logout") %></a></li>
                        </ul>
                    </li>
                </ul>
                <!-- /.ace-nav -->
            </div>
            <!-- /.navbar-header -->


        </div>



    </div>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try {
                ace.settings.check('main-container', 'fixed');
            } catch (e) { }
        </script>

        <div class="main-container-inner">
            <a class="menu-toggler" id="menu-toggler" href="#">
                <span class="menu-text"></span>
            </a>

            <div class="Region sidebar" id="sidebar">
                <script type="text/javascript">
                    try {
                        ace.settings.check('sidebar', 'fixed');
                    } catch (e) { }
                </script>


                <div id="sidebar-shortcuts" class="sidebar-shortcuts">

                    <div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
                        <button class="btn btn-success">
                            <i class="icon-signal"></i>
                        </button>

                        <button class="btn btn-info">
                            <i class="icon-pencil"></i>
                        </button>

                        <button class="btn btn-warning">
                            <i class="icon-group"></i>
                        </button>

                        <button class="btn btn-danger">
                            <i class="icon-cogs"></i>
                        </button>
                    </div>

                    <div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
                        <span class="btn btn-success"></span>

                        <span class="btn btn-info"></span>

                        <span class="btn btn-warning"></span>

                        <span class="btn btn-danger"></span>
                    </div>

                </div>

                <script>
                    function navListController($scope){
                        $scope.memberRights = <%= Provider.CurrentMember.GetAllRights().ToJSON() %>;
                    }
                </script>


                <ul class="nav nav-list" ng-controller="navListController">

                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-home"></i>
                            <span class="menu-text"><%=Provider.TR("Welcome") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#/dashboard">
                                    <i class="icon-dashboard"></i>
                                    <%=Provider.TR("Dashboard") %> 
                                </a>
                            </li>
                        </ul>

                    </li>
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-cloud"></i>
                            <span class="menu-text">API</span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li ng-show="memberRights.ApiClientView">
                                <a href="#/List/ApiClient">
                                    <i class="icon-cloud"></i>
                                    <%=Provider.TR("APIs & Clients") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ClientView">
                                <a href="#/List/Client">
                                    <i class="icon-cloud"></i>
                                    <%=Provider.TR("Clients") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ApiSessionView">
                                <a href="#/List/ApiSession">
                                    <i class="icon-cloud"></i>
                                    <%=Provider.TR("Sessions") %> 
                                </a>
                            </li>
                        </ul>
                    </li>
                    
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-home"></i>
                            <span class="menu-text"><%=Provider.TR("Domain Marketing") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#/DomainMarketingDashboard">
                                    <i class="icon-dashboard"></i>
                                    <%=Provider.TR("Dashboard") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/DMPredefinedMessage">
                                    <i class="icon-dashboard"></i>
                                    <%=Provider.TR("Predefined") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/DMMessage">
                                    <i class="icon-user"></i>
                                    <%=Provider.TR("Admin Message") %> 
                                </a>
                            <li>
                        </ul>

                    </li>
                    <li>

                        <a href="#" class="dropdown-toggle">
                            <i class="icon-user"></i>
                            <span class="menu-text">Members</span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li ng-show="memberRights.MemberView">
                                <a href="#/List/Member">
                                    <i class="icon-user"></i>
                                    <%=Provider.TR("Members") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ResellerView">
                                <a href="#/List/Reseller">
                                    <i class="icon-user"></i>
                                    <%=Provider.TR("Resellers") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.RoleView">
                                <a href="#/List/Role">
                                    <i class="icon-tag"></i>
                                    <%=Provider.TR("Roles & Rights") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ResellerTypeView">
                                <a href="#/List/ResellerType">
                                    <i class="icon-tag"></i>
                                    <%=Provider.TR("Reseller Types") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.NewsletterDefinitionView">
                                <a href="#/List/NewsletterDefinition">
                                    <i class="icon-envelope"></i>
                                    <%=Provider.TR("Newsletters") %> 
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-group"></i>
                            <span class="menu-text"><%=Provider.TR("CRM") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#/List/Feedback">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Feedback") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/CrmActivity">
                                    <i class="icon-phone-sign"></i>
                                    <%=Provider.TR("Tickets") %> 
                                </a>
                            </li>
                        </ul>

                    </li>

                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-shopping-cart"></i>
                            <span class="menu-text"><%=Provider.TR("Orders") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li ng-show="memberRights.OrderView">
                                <a href="#/List/Order">
                                    <i class="icon-shopping-cart"></i>
                                    <%=Provider.TR("Orders") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.CouponView">
                                <a href="#/List/Coupon">
                                    <i class="icon-thumbs-up-alt"></i>
                                    <%=Provider.TR("Coupons") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.MdfView">
                                <a href="#/List/Mdf">
                                    <i class="icon-thumbs-up-alt"></i>
                                    <%=Provider.TR("MDFs") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ExchangeRateView">
                                <a href="#/List/ExchangeRate">
                                    <i class="icon-money"></i>
                                    <%=Provider.TR("Exchange Rates") %> 
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-gamepad"></i>
                            <span class="menu-text"><%=Provider.TR("Product") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li ng-show="memberRights.SupplierView">
                                <a href="#/List/Supplier">
                                    <i class="icon-truck"></i>
                                    <%=Provider.TR("Suppliers") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ProductTypeView">
                                <a href="#/List/ProductType">
                                    <i class="icon-gamepad"></i>
                                    <%=Provider.TR("Product Types") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.ProductView">
                                <a href="#/List/Product">
                                    <i class="icon-gamepad"></i>
                                    <%=Provider.TR("Products") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.LifeCycleView">
                                <a href="#/List/LifeCycle">
                                    <i class="icon-calendar"></i>
                                    <%=Provider.TR("Life Cycles") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.PropertySetView">
                                <a href="#/List/PropertySet">
                                    <i class="icon-calendar"></i>
                                    <%=Provider.TR("Property Sets") %> 
                                </a>
                            </li>

                            <li>
                                <a href="#/List/JobScheduler">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Job Scheduler") %> 
                                </a>
                            </li>
                        </ul>
                    </li>

                    <% if (Provider.CurrentApi.Id == "SignSec")
                       { %>
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-lock"></i>
                            <span class="menu-text"><%=Provider.TR("SSL") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">


                            <li ng-show="memberRights.MemberSSLView">
                                <a href="#/List/MemberSSL">
                                    <i class="icon-unlock-alt"></i>
                                    <%=Provider.TR("SignSec Certificates") %> 
                                </a>
                            </li>



                        </ul>
                    </li>
                    <% } %>

                    <% if (Provider.CurrentApi.Id == "DealerSafe")
                       { %>
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-globe"></i>
                            <span class="menu-text"><%=Provider.TR("Domain") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">


                            <li ng-show="memberRights.MemberDomainView">
                                <a href="#/List/MemberDomain">
                                    <i class="icon-globe"></i>
                                    <%=Provider.TR("Domains") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/DomainContact">
                                    <i class="icon-user"></i>
                                    <%=Provider.TR("Domain Contact") %> 
                                </a>
                            </li>



                        </ul>
                    </li>
                    <% } %>


                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-envelope"></i>
                            <span class="menu-text"><%=Provider.TR("Communication") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#/List/CCProfile">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Profile") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/CCEmailSocket">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("E-Mail Socket") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/CCSmsSocket">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Sms Socket") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/CCMessageGroup">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Message Group") %> 
                                </a>
                            </li>
                            <li>
                                <a href="#/List/CCMessageTemplate">
                                    <i class="icon-comment"></i>
                                    <%=Provider.TR("Message Template") %> 
                                </a>
                            </li>
                        </ul>

                    </li>

                    <li>

                        <a href="#" class="dropdown-toggle">
                            <i class="icon-list"></i>
                            <span class="menu-text"><%=Provider.TR("Definitions") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li ng-show="memberRights.LanguageView">
                                <a href="#/List/Language">
                                    <i class="icon-list"></i>
                                    <%=Provider.TR("Languages") %> 
                                </a>
                            </li>
                            <li ng-show="memberRights.CountryView">
                                <a href="#/List/Country">
                                    <i class="icon-list"></i>
                                    <%=Provider.TR("Countries") %> 
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class="dropdown-toggle">
                            <i class="icon-desktop"></i>
                            <span class="menu-text"><%=Provider.TR("Logs & Tools") %> </span>
                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">

                            <li ng-show="memberRights.RightEdit">
                                <a href="#/APIDemo">
                                    <i class="icon-cloud"></i>
                                    <%=Provider.TR("API Demo") %>
                                </a>
                            </li>

                            <li ng-show="memberRights.RightEdit">
                                <a href="#/List/Job">
                                    <i class="icon-hdd"></i>
                                    <%=Provider.TR("Logs") %>
                                </a>
                            </li>

                            <li ng-show="memberRights.RightEdit">
                                <a href="#/LogReport">
                                    <i class="icon-th-list"></i>
                                    <%=Provider.TR("API Usage Report") %>
                                </a>
                            </li>

                        </ul>
                    </li>
                </ul>

                <div class="sidebar-collapse" id="sidebar-collapse">
                    <i class="icon-double-angle-left" data-icon1="icon-double-angle-left" data-icon2="icon-double-angle-right"></i>
                </div>

                <script type="text/javascript">
                    try {
                        ace.settings.check('sidebar', 'collapsed');
                    } catch (e) { }
                </script>

            </div>

            <div class="main-content">
                <div class="Region breadcrumbs" id="breadcrumbs">
                    <script type="text/javascript">
                        try {
                            ace.settings.check('breadcrumbs', 'fixed');
                        } catch (e) { }
                    </script>

                    <ul class="breadcrumb">
                        <li>
                            <i class="icon-home home-icon"></i>
                            <a href="/Default.aspx"><%=Provider.CurrentApi.Name %></a>
                        </li>
                        <li>
                            <a href="#"><%=Provider.TR("Other Pages") %></a>
                        </li>
                        <li class="active"><%=Provider.TR("Blank Page") %></li>
                    </ul>

                    <div id="nav-search" class="nav-search">
                        <form class="form-search">
                            <span class="input-icon">
                                <input type="text" placeholder="<%=Provider.TR("Search ...") %>" class="nav-search-input" id="nav-search-input" autocomplete="off" />
                                <i class="icon-search nav-search-icon"></i>
                            </span>
                        </form>
                    </div>

                </div>

                <div id="listForm" class="page-content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="Region row" id="contentDiv" animated-view>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!-- /.main-container-inner -->

        <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
            <i class="icon-double-angle-up icon-only bigger-110"></i>
        </a>
    </div>
    <!-- /.main-container -->

    <!-- basic scripts -->
    <script src="/Assets/js/jquery-ui-1.10.3.full.min.js"></script>
    <script src="/Assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <!--script src="/Assets/js/jquery.ui.touch-punch.min.js"></script-->
    <script src="/Assets/js/chosen.jquery.min.js"></script>
    <script src="/Assets/js/fuelux/fuelux.spinner.min.js"></script>
    <script src="/Assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script src="/Assets/js/date-time/bootstrap-timepicker.min.js"></script>
    <!--script src="/Assets/js/date-time/moment.min.js"></script-->
    <script src="/Assets/js/date-time/daterangepicker.min.js"></script>
    <!--script src="/Assets/js/bootstrap-colorpicker.min.js"></script-->
    <!--script src="/Assets/js/jquery.knob.min.js"></script-->
    <!--script src="/Assets/js/jquery.autosize.min.js"></script-->
    <!--script src="/Assets/js/jquery.inputlimiter.1.3.1.min.js"></script-->
    <script src="/Assets/js/jquery.maskedinput.min.js"></script>
    <!--script src="/Assets/js/bootstrap-tag.min.js"></script-->
    <script src="/Assets/js/jquery.dataTables.min.js"></script>
    <script src="/Assets/js/jquery.dataTables.bootstrap.js"></script>
    <!--script src="/Assets/js/jquery.nestable.min.js"></script-->
    <script src="/Assets/js/jquery.colorbox-min.js"></script>
    <script src="/Assets/js/jquery.hotkeys.min.js"></script>
    <script src="/Assets/js/uncompressed/bootstrap-wysiwyg.js"></script>
    <!-- ace scripts -->

    <!--for Dashboar -->
    <script src="/Assets/js/uncompressed/flot/jquery.flot.js"></script>
    <script src="/Assets/js/uncompressed/flot/jquery.flot.time.js"></script>
    <script src="/Assets/js/uncompressed/flot/jquery.flot.pie.js"></script>
    <script src="/Assets/js/uncompressed/flot/jquery.flot.resize.js"></script>
    <script src="/Assets/js/jqvmap/jquery.vmap.js" type="text/javascript"></script>
    <script src="/Assets/js/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
    <!--for Dashboar -->

    <script src="/Assets/js/uncompressed/ace-elements.js"></script>
    <script src="/Assets/js/uncompressed/ace.js"></script>


    <script src="/Assets/js/angular.min.js"></script>
    <script src="/Assets/js/angular-route.js"></script>
    <script src="/Assets/js/angular-filter.min.js"></script>
    <script src="/Assets/Utility.js"></script>


    <script src="/Staff/JS/app.js"></script>
    <script src="/Staff/JS/controllers.js"></script>
    <script src="/Staff/JS/entityService.js"></script>
    <script src="/Staff/JS/directives.js"></script>
    <div class="modal"></div>
</body>
</html>
