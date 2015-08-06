<list-header title="Coupons"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Type" field="CouponType"></th>
            <th column-header="Value" field="Value"></th>
            <th column-header="MultiUsage" field="MultiUsage"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.CouponType}}</td>
            <td>{{entity.Value}}</td>
            <td>{{entity.MultiUsage}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>