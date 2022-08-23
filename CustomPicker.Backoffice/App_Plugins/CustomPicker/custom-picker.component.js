(function () {
    angular.module('umbraco')
        .component('customPicker', {
            bindings: {
                config: '<',
                model: '<ngModel',
                onSelect: '&?'
            },
            require: {
                ngModel: 'ngModel'
            },
            template: `
                <umb-node-preview ng-repeat="selectedItem in vm.selectedItems"
                      name="selectedItem.name"
                      icon="selectedItem.icon"
                      description="selectedItem.description"
                      allow-remove="true"
                      on-remove="vm.remove($index)">
                </umb-node-preview>
                <a class="umb-node-preview-add" ng-if="vm.config.allowMultiple === '1' || !vm.selectedItems.length"
                   ng-click="vm.openPicker()"
                   prevent-default>
                    <localize key="general_add">Add</localize>
                </a>

                <div ng-if="vm.error" class="alert alert-warning">
                    {{ vm.error }}
                </div>
            `,
            controller: CustomPickerController,
            controllerAs: 'vm'
        });

    CustomPickerController.$inject = ['$http', '$routeParams', 'editorService',];
    function CustomPickerController($http, $routeParams, editorService) {
        var vm = this;
        vm.$onInit = function () {
            console.log(vm.config);
            if (vm.model) {
                vm._getInfo();
            }
        }

        vm._getInfo = () => {
            vm.loading = true;
            return $http.get('/umbraco/backoffice/custompicker/custompickerapi/getinfo', {
                params: {
                    ids: vm.model.split(','),
                    key: vm.config.picker,
                    culture: $routeParams.cculture || $routeParams.mculture
                }
            })
                .then((response) => {
                    vm.selectedItems = response.data;
                    vm.loading = false;
                })
                .catch((error) => {
                    vm.error = error.message;
                });
        }

        vm.openPicker = function () {
            editorService.open({
                picker: vm.config.picker,
                size: 'small',
                view: '/app_plugins/custompicker/overlay.html',
                allowMultiple: vm.config.allowMultiple === '1',
                disableSearch: vm.config.disableSearch === '1',
                title: vm.title,
                submit: function (model) {
                    if (model && model.selection.length > 0) {
                        var items = {};
                        if (vm.selectedItems) {
                            for (var i = 0; i < vm.selectedItems.length; i++) {
                                var item = vm.selectedItems[i];
                                items[item.id] = item;
                            }
                        }
                        for (var i = 0; i < model.selection.length; i++) {
                            var item = model.selection[i];
                            items[item.id] = item;
                        }
                        var ids = Object.keys(items);
                        if (ids.length) {
                            var selection = [];
                            for (var i = 0; i < ids.length; i++) {
                                selection.push(items[ids[i]]);
                            }
                            vm.selectedItems = selection;
                            if (vm.config.allowMultiple) {
                                vm.model = ids.join(',');
                            }
                            else {
                                vm.model = ids[0];
                            }
                        }
                        else {
                            vm.model = null;
                        }
                        vm.ngModel.$setViewValue(vm.model);
                    }
                    if (vm.onSelect) {
                        if (vm.config.allowMultiple) {
                            vm.onSelect({
                                selection: vm.model
                            });
                        }
                        else {
                            vm.onSelect({
                                selection: vm.model[0]
                            });
                        }
                    }
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            });
        };

        vm.remove = function (index) {
            vm.selectedItems.splice(index, 1);
            if (!vm.selectedItems.length) {
                vm.model = null;
            }
            else {
                var items = [];
                vm.selectedItems.forEach(item => {
                    items.push(item.id);
                });
                vm.model = items.join(',');
            }
            vm.ngModel.$setViewValue(vm.model);
            if (vm.onSelect) {
                if (vm.config.allowMultiple) {
                    vm.onSelect({
                        selection: vm.model
                    });
                }
                else {
                    vm.onSelect({
                        selection: vm.model[0]
                    });
                }
            }
        }
    }
})()