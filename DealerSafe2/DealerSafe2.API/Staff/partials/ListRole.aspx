<list-header title="Roles"></list-header>

<div class="row">
    
	<div class="col-xs-12 col-sm-4 widget-container-span"  ng-repeat="role in list | orderBy:'Name'" ng-class="{deleted:role.IsDeleted}" style="margin-top:12px">
		<div class="widget-box">
			<div class="widget-header">
			    <h5>
			        <span ng-if="renameRole!=role" ng-click="rename(role)">{{role.Name}}</span>
                    <input ng-if="renameRole==role" ng-model="role.Name" ng-enter="renameSave()" class="form-control" type="text" style="width: 65%;float: left;height: 24px;margin-top: 6px;"/>
			    </h5>

				<div class="widget-toolbar">
					<a ng-if="renameRole!=role" ng-click="rename(role)" data-action="settings">
						<i class="icon-edit"></i>
					</a>
					<a ng-if="renameRole==role" ng-click="renameCancel()" data-action="close">
						<i class="icon-remove"></i>
					</a>
				</div>
			</div>

			<div class="widget-body">
			    <div class="widget-main">
			        <div ng-if="!role.currRight">
			            {{role.MemberCount}} members, 
						<a ng-click="readRights(role)">{{role.RightCount}} rights</a>
						(<a ng-click="newRight(role)">add</a>)
						<div style="max-height:300px;overflow-y:auto">
			            <table ng-if="role.rights" class="table table-striped table-bordered" style="margin-top: 20px">
			                <tr ng-repeat="rr in role.rights | orderBy:'Right'" ng-class="{deleted:rr.IsDeleted}">
			                    <td>
			                        <i class="icon-ok green"></i>
			                        {{rr.Right}}
			                    </td>
			                    <td>
			                        <i class="icon-edit orange" ng-click="editRight(role, rr)"></i>
			                        <i class="icon-trash red" ng-click="deleteRight(role, rr)"></i>
			                    </td>
			                </tr>
			            </table>
						</div>
			        </div>
                    
			        <div ng-if="role.currRight">
			            <form class="form-horizontal" role="form" autocomplete="off">
			                <input type="text" ng-model="role.currRight.Id" name="Id" style="display:none"/>
			                <input type="text" ng-model="role.currRight.RoleId" name="RoleId" style="display:none"/>
			                <div class="row">
		
			                    <div class="form-group">
			                        <label for="Name" class="col-sm-3 control-label no-padding-right"> Right </label>
			                        <div class="col-sm-9">
				
                                    <select ng-model="role.currRight.Right" ng-options="i.Id as i.Name for i in rightOptions | orderBy:'Name'" class="col-sm-6">
                                        <option value=""></option>
                                    </select>
                                    <input type="text" style="display:none" ng-model="role.currRight.Right" name="RightId" />
		
			                        </div>
			                    </div>
			                </div>

			                <div class="clearfix form-actions">
			                    <div class="text-right">
			                        <button class="btn btn-xs btn-primary" type="button" ng-click="saveRight(role)">
			                            <i class="icon-ok bigger-110"></i>
			                            Save
			                        </button>
			                        &nbsp; 
			                        <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditRight(role)">
			                            <i class="icon-undo bigger-110"></i>
			                            Cancel
			                        </button>
			                    </div>
			                </div>

			            </form>
			        </div>
                    

			    </div>
			</div>
		</div>
	</div>
    
</div>

<list-footer></list-footer>