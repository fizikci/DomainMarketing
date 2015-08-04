<list-header title="Message Template"></list-header>


<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="Message Group" name="CCMessageGroupId" model="selectedMsgGroup" options="i.Id as i.Name for i in MsgGroups"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<div style="clear: both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
             <th column-header="Id" field="Id"></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Subject" field="Subject"></th>
            <th column-header="Message Group" field="CCMessageGroupName"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Id}}</td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.Subject}}</td>
            <td>{{entity.CCMessageGroupName}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>



<list-footer></list-footer>


