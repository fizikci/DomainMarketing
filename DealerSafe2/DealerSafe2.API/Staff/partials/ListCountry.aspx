<list-header title="Countries"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="OfficialName" field="OfficialName"></th>

            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td>{{entity.Name}}</td>
            <td>{{entity.OfficialName}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>
