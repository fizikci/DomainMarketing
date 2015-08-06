<list-header title="Product Types"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Property Set" field="PropertySetName"></th>
            <th column-header="Life Cycle" field="LifeCycleName"></th>
            <th column-header="Products" field="ProductCount"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td link-to-parent="PropertySet">{{entity.PropertySetName}}</td>
            <td link-to-parent="LifeCycle">{{entity.LifeCycleName}}</td>
            <td>{{entity.ProductCount}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>
