<list-header title="Logs"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="State" name="Status" model="selectedState" options="i.Id as i.Name for i in StateList"></input-select>
    <input-select no-empty-option="1" horizontal="1" label="Command" name="Command" model="selectedCommand" options="i.Id as i.Name for i in CommandList"></input-select>
    <input-select no-empty-option="1" horizontal="1" label="Executer Type" name="Executer" model="selectedExecuter" options="i.Id as i.Name for i in ExecuterList"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Job Id" field="Id"></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Command" field="Command"></th>
            <th column-header="Command Parameter" field="CommandParameter"></th>
            <th column-header="Executer Type" field="Executer"></th>
            <th column-header="Status" field="State"></th>
            <th column-header="Create Date" field="StartDate"></th>

            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Id}}</td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.Command}}</td>
            <td>{{entity.CommandParameter}}</td>
            <td>{{entity.Executer}}</td>
            <td>{{entity.State}}</td>
            <td>{{entity.StartDate | date:'yyyy.MM.dd HH:mm'}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer no-add-new="true"></list-footer>
