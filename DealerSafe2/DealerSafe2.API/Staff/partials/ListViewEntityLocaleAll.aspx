<list-header title="Çeviriler"></list-header>
<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select horizontal="1" label="Entity" name="EntityName" model="filter.EntityName" options="i.Id as i.Name for i in EntityNameList"></input-select>               
    <input-select horizontal="1" label="Field" name="FieldName" model="filter.FieldName" options="i.Id as i.Name for i in FieldNameList"></input-select>               
    <input type="button" value="Filtrele" ng-click="search()" />
</form>
<page-size></page-size>
<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th>#</th>
            <th column-header="Entity" field="EntityName"></th>
            <th column-header="Field" field="FieldName"></th>
            <th style="width:430px" column-header="Türkçe" field="Turkce"></th>
            <th column-header="English" field="English"></th>
            <th column-header="French" field="French"></th>
            <th column-header="German" field="German"></th>
            <th column-header="Russian" field="Russian"></th>
            <th column-header="Arabic" field="Arabic"></th>           
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list">
            <td indexer></td>
            <td>{{entity.EntityName}}</td>
            <td>{{entity.FieldName}}</td>
            <td>{{entity.Turkce}}</td>
            <td ng-click="edit(entity, 'English', 'en')"><i ng-if="entity.English" class="icon-ok bigger-130 green"></i> <i ng-if="!entity.English" class="icon-edit bigger-130 orange"></i></td>
            <td ng-click="edit(entity, 'French', 'fr')"><i ng-if="entity.French" class="icon-ok bigger-130 green"></i> <i ng-if="!entity.French" class="icon-edit bigger-130 orange"></i></td>
            <td ng-click="edit(entity, 'German', 'de')"><i ng-if="entity.German" class="icon-ok bigger-130 green"></i> <i ng-if="!entity.German" class="icon-edit bigger-130 orange"></i></td>
            <td ng-click="edit(entity, 'Russian', 'ru')"><i ng-if="entity.Russian" class="icon-ok bigger-130 green"></i> <i ng-if="!entity.Russian" class="icon-edit bigger-130 orange"></i></td>
            <td ng-click="edit(entity, 'Arabic', 'ar')"><i ng-if="entity.Arabic" class="icon-ok bigger-130 green"></i> <i ng-if="!entity.Arabic" class="icon-edit bigger-130 orange"></i></td>          
        </tr>
    </tbody>
</table>


<style>
    table i {
        cursor:pointer
    }
</style>