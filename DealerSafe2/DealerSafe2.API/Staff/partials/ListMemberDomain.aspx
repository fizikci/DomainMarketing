<list-header title="Domains"></list-header>

<pagination></pagination>


<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Domain" field="DomainName"></th>
            <th column-header="Order" field="DisplayName"></th>
            <th column-header="Member" field="MemberName"></th>
            <th column-header="Renewal Mode" field="RenewalMode"></th>
            <th column-header="Create Date" field="InsertDate"></th>
            <th column-header="Renewal Date" field="StartDate"></th>
            <th column-header="Expire Date" field="EndDate"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.DomainName}}</td>
            <td link-to-parent="Order">{{entity.DisplayName}}</td>
            <td link-to-parent="Member">{{entity.MemberName}}</td>
            <td>{{entity.RenewalMode}}</td>
            <td>{{entity.InsertDate | date}}</td>
            <td>{{entity.StartDate | date}}</td>
            <td>{{entity.EndDate | date}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>
