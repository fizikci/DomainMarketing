<list-header title="APIs & Clients"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="API" field="ApiName"></th>
            <th column-header="Client" field="ClientName"></th>
            <th column-header="URL" field="Url"></th>
            <th column-header="" field=""></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td>{{entity.ApiName}}</td>
            <td>{{entity.ClientName}}</td>
            <td>{{entity.Url}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>