<list-header title="Feedbacks"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Subject" field="Subject"></th>
            <th column-header="From" field="Email"></th>
            <th column-header="Department" field="Department"></th>
            <th column-header="Date" field="InsertDate"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Subject}}</td>
            <td>{{entity.Email}}</td>
            <td>{{entity.Department}}</td>
            <td>{{entity.InsertDate | date:'yyyy.MM.dd HH:mm'}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>