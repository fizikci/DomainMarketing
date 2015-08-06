<list-header title="MDFs"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="For" field="ResellerTypeId"></th>
            <th column-header="Announce" field="AnnounceStartDate"></th>
            <th column-header="Validity" field="StartDate"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.ResellerTypeId}}</td>
            <td>{{entity.AnnounceStartDate | date}} - {{entity.AnnounceEndDate | date}}</td>
            <td>{{entity.StartDate | date}} - {{entity.EndDate | date}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>