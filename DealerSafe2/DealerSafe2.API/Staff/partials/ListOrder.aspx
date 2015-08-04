<list-header title="Orders"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="State" name="State" model="selectedState" options="i.Id as i.Name for i in StateList"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<div ng-show="member" style="float:right;font-size: large">
    by <a href="#/View/Member/{{member.Id}}">{{member.FullName}}</a>
    <img ng-src="{{member.Avatar}}" style="height: 32px"/>
</div>
<div style="clear:both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Date" field="InsertDate"></th>
            <th column-header="Member" field="MemberEmail"></th>
            <th column-header="Content" field="DisplayName"></th>
            <th column-header="Total Price" field="TotalPrice"></th>
            <th column-header="State" field="State"></th>
            <th column-header="Company" field="InvoiceCompanyName"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.InsertDate | date:"dd/MM/yyyy HH:mm"}}</td>
            <td link-to-parent="Member">
                {{entity.MemberEmail}}
                <i ng-if="entity.MemberState=='Confirmed'" class="icon-ok bigger-130 green"></i>
                <img ng-if="entity.MemberMedal" ng-src="/Assets/images/icons/medal_{{entity.MemberMedal}}.png" title="{{entity.MemberMedal}} Partnership" />
            </td>
            <td>{{entity.DisplayName}}</td>
            <td class="text-right">
                <i ng-if="entity.CouponItemId" title="Coupon used" class="icon-download bigger-130 purple"></i> 
                {{entity.TotalPrice/100 | currency:entity.Currency+' '}}
            </td>
            <td>{{entity.State}}</td>
            <td>{{entity.InvoiceCompanyName}}</td>
            <td operations>
                <a class="dtBtn blue" href="#/View/Order/{{entity.Id}}"><i class="icon-search bigger-130" title="View"></i></a>
            </td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>