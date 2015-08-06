<div class="page-header">
    <h1 class="blue">
        Order
    <small>
        <i class="icon-double-angle-right"></i>
        View order details
    </small>
    </h1>
</div>

<div class="widget-box transparent invoice-box">
    <div class="widget-header widget-header-large">
        <h3 class="grey lighter pull-left position-relative">
            <i class="icon-shopping-cart blue"></i>
            {{entity.DisplayName}}
        </h3>

        <div class="widget-toolbar no-border invoice-info">
            <span class="invoice-info-label">Invoice:</span>
            <span class="red">#{{entity.InvoiceNo}}</span>

            <br>
            <span class="invoice-info-label">Date:</span>
            <span class="blue">{{entity.OrderDate | date:"dd/MM/yyyy HH:mm"}}</span>
        </div>

        <div class="widget-toolbar hidden-480">
            <a href="#">
                <i class="icon-print"></i>
            </a>
        </div>
    </div>

    <div class="widget-body">
        <div class="widget-main padding-24">
            <div class="row">
                <div class="col-sm-4">
                    <address>
                        <strong ng-show="address.InvoiceTitle">{{address.InvoiceTitle}}<br/></strong>
                        <span ng-show="address.AddressText">{{address.AddressText}}<br/></span>
                        <span ng-show="address.CountryId">{{address.CityId}}, {{address.CountryId}} {{address.ZipCode}}<br/></span>
                        <span ng-show="address.PhoneNumber"><abbr title="Phone">P:</abbr>{{address.PhoneNumber}}</span>
                    </address>
                </div><!-- /span -->

            </div><!-- row -->

            <div class="space"></div>

            <div>
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th class="center"></th>
                            <th>Product</th>
                            <th class="hidden-xs">Description</th>
                            <th class="hidden-480">Amount</th>
                            <th>Total</th>
                        </tr>
                    </thead>

                    <tbody ng-repeat="i in entity.items">
                        <tr ng-class="{deleted:i.IsDeleted}">
                            <td>
                                {{$index+1}}.
                            </td>
                            <td>
                                <i ng-if="!i.expanded" class="icon-plus-sign-alt blue" ng-click="expand(i)"></i>
                                <i ng-if="i.expanded" class="icon-minus-sign-alt blue" ng-click="collapse(i)"></i>
                                {{i.ProductName}}
                            </td>
                            <td class="hidden-xs">{{i.DisplayName}}</td>
                            <td class="hidden-480">{{i.Amount + ' ' + i.Unit}}</td>
                            <td class="text-right">{{i.Price/100 | currency: i.Currency + ' '}}</td>
                        </tr>
                        <tr class="sub" ng-repeat="c in i.items" ng-class="{deleted:c.IsDeleted}">
                            <td></td>
                            <td>{{c.ProductName}}</td>
                            <td class="hidden-xs">{{c.DisplayName}}</td>
                            <td class="hidden-480">{{c.Amount + ' ' + c.Unit}}</td>
                            <td class="text-right"></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <h4 class="text-right">
                        Total amount :
                        <span class="green">{{entity.TotalPrice/100 | currency:entity.Currency+' '}}</span>
                    </h4>
                    <h4 class="text-right">
                        Discount <span ng-show="entity.DiscountName">({{entity.DiscountName}} <span ng-show="entity.CouponItemId">{{entity.CouponItemId}}</span>)</span>:
                        <span class="red">{{entity.Discount/100 | currency:entity.Currency+' '}}</span>
                    </h4>
                </div>
            </div>

        </div>
    </div>
</div>



<div ng-show="entity.State=='Order'" class="widget-box transparent invoice-box">
    <div class="widget-header widget-header-large">
        <h3 class="grey lighter pull-left position-relative">
            <i class="icon-cog orange"></i>
            Related Jobs
        </h3>
    </div>

    <div class="widget-body">
        <div class="widget-main padding-24">

            <div>
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Command</th>
                            <th>Name</th>
                            <th>State</th>
                            <th>StartDate</th>
                            <th>TryCount</th>
                            <th>Executer</th>
                        </tr>
                    </thead>

                    <tbody ng-repeat="j in entity.jobs">
                        <tr>
                            <td>
                                {{$index+1}}.
                            </td>
                            <td>
                                <i ng-show="!j.expanded" class="icon-plus-sign-alt blue" ng-click="expandJD(j)"></i>
                                <i ng-show="j.expanded" class="icon-minus-sign-alt blue" ng-click="collapseJD(j)"></i>
                                {{j.Command}}
                            </td>
                            <td>{{j.Name}}</td>
                            <td>{{j.State}}</td>
                            <td>{{j.StartDate | date:"dd/MM/yyyy HH:mm"}}</td>
                            <td>{{j.TryCount}}</td>
                            <td>{{j.Executer}}</td>
                        </tr>
                        <tr ng-repeat="jd in j.items | orderBy:'InsertDate'">
                            <td></td>
                            <td></td>
                            <td colspan="5">
                                <i ng-show="!jd.expanded" class="icon-plus-sign-alt blue" ng-click="jd.expanded=true"></i>
                                <i ng-show="jd.expanded" class="icon-minus-sign-alt blue" ng-click="jd.expanded=false"></i>
                                {{jd.InsertDate | date:"dd/MM/yyyy HH:mm"}}: {{jd.RequestUrl}}<br/>
                                <blockquote ng-show="jd.expanded">{{jd.Request}}</blockquote>
                                <blockquote ng-show="jd.expanded">{{jd.Response}}</blockquote>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </div>
</div>

<style>
    blockquote {word-break: break-all;}
</style>