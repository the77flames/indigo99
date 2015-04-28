define(['durandal/system', 'services/logger', 'services/global', 'knockout', 'plugins/http', 'services/scripts'],
    function (system, logger, global, ko, http, scripts) {
        // var service = ''; //global.serviceUrl + 'NewsServiceRESTAPI/';

        var vm = function (url) {
            var m = {};

            m.service = url;
            m.get= get;
            m.getById = getById;
            m.update = update;
            m.deleteById = deleteById;
        };

        return vm;

        function get(observableList, d) {
            var model = { date: d.getFullYear() + '-' + d.getMonth() + '-' + d.getDate() };
            var promise = http.get(vm.service, model);

            return promise.then(function(data) {
                observableList(data);
            }).fail(function(error) {
                logger.logError("Error while loading objects: " + scripts.jsonMessage(error), null, "Get List", true);
            });
        }

        function update(obj) {
            return http.post(vm.service, obj);
        }

        function getById(id) {
            return http.get(vm.service, id);
        }

        function deleteById(id) {
            return http.delete(vm.service, id);
        }
    });