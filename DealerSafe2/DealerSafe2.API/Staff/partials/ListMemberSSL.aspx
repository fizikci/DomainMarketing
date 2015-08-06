<list-header title="Certificates"></list-header>

<pagination></pagination>


<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Date" field="StartDate"></th>
            <th column-header="Domain" field="DomainName"></th>
            <th column-header="Order" field="DisplayName"></th>
            <th column-header="Member" field="Email"></th>
            <th column-header="State" field="State"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td>{{entity.StartDate | date}}</td>
            <td link-to-view>{{entity.DomainName}}</td>
            <td link-to-parent="Order">{{entity.DisplayName}}</td>
            <td link-to-parent="Member">{{entity.Email}}</td>
            <td>{{entity.State}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>
