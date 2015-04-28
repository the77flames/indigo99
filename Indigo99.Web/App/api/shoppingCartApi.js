define(['durandal/system', 'services/logger', 'services/global', 'knockout', 'plugins/http', 'services/scripts'],
    function (system, logger, global, ko, http, scripts) {
        var service = global.serviceUrl + 'shoppingCart';

        var vm = {
            get: get,
            getById: getById,
            update: update,
            deleteById: deleteById
        };

        return vm;

        function get(observableList, id, cat) {
            cat = cat || '0';
            var promise = http.get(service + '/' + id + '/' + cat); //(id ? '/' + id + '/' + cat : ''));

            return promise.then(function (data) {
                observableList(data);
            }).fail(function (error) {
                logger.logError("Error while loading cart info: " + scripts.jsonMessage(error), null, "Get Product List", true);
            });
        }

        function addToCart(cartInfo) {
            return http.post(service, cartInfo);
        }

        function update(cartInfo) {
            return http.post(service, cartInfo);
        }

        function getById(id, cat) {
            return http.get(service + (id ? '/' + id + '/' + cat : '0'));
        }

        function deleteById(id) {
            return http.delete(service, id);
        }
    });