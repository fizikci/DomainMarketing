<list-header title="Resellers"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="Type" name="ResellerTypeName" model="selectedResellerTypeName" options="i.Name as i.Name for i in ResellerTypes"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Email" field="Email"></th>
            <th column-header="Name" field="ResellerName"></th>
            <th column-header="Type" field="ResellerTypeName"></th>
            <th column-header="Date" field="InsertDate"></th>

            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Email}}</td>
            <td>{{entity.ResellerName}}</td>
            <td>{{entity.ResellerTypeName}}</td> 
            <td>{{entity.InsertDate | date:'yyyy.MM.dd'}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer no-add-new="true"></list-footer>
