define(['durandal/system', 'services/logger', 'services/global', 'knockout', 'plugins/http', 'services/scripts'],
    function (system, logger, global, ko, http, scripts) {
        var service = global.serviceUrl + 'products';

        var vm = {
            get: get,
            getById: getById,
            update: update,
            deleteById: deleteById
        };

        return vm;

        function get(observableList, id, cat) {
            var serviceUrl = service + '/';
            if (cat) {
                serviceUrl += +id + '/' + cat;
            }
            var promise = http.get(serviceUrl); 

            return promise.then(function (data) {
                observableList(data);
            }).fail(function (error) {
                logger.logError("Error while loading products: " + scripts.jsonMessage(error), null, "Get Product List", true);
            });
        }

        function update(product) {
            return http.post(service, product);
        }

        function getById(id, cat) {
            return http.get(service + (id ? '/' + id + '/' + cat : '0'));
        }

        function deleteById(id) {
            return http.delete(service, id);
        }
    });