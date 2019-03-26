var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var DC;
(function (DC) {
    var Storage;
    (function (Storage_1) {
        var Storage = /** @class */ (function () {
            function Storage() {
            }
            // 存储到本地持久化缓存
            Storage.prototype.SetItem = function (type, key, data) {
                if (type == "localStorage") {
                    window.localStorage.setItem(key, data);
                }
                else {
                    window.sessionStorage.setItem(key, data);
                }
            };
            // 从本地持久化缓存中读取数据
            Storage.prototype.GetItem = function (type, key) {
                if (type == "localStorage") {
                    return window.localStorage.getItem(key);
                }
                else {
                    return window.sessionStorage.getItem(key);
                }
            };
            // 删除数据项
            Storage.prototype.RemoveItem = function (type, key) {
                if (type == "localStorage") {
                    window.localStorage.removeItem(key);
                }
                else {
                    window.sessionStorage.removeItem(key);
                }
            };
            // 删除所有数据
            Storage.prototype.Clear = function (type) {
                if (type == "localStorage") {
                    window.localStorage.clear();
                }
                else {
                    window.sessionStorage.clear();
                }
            };
            // 获取本地持久化缓存中的数量
            Storage.prototype.Length = function (type) {
                if (type == "localStorage") {
                    return window.localStorage.length;
                }
                else {
                    return window.sessionStorage.length;
                }
            };
            // 获取本地持久化缓存中的指定序号的Key名
            Storage.prototype.Key = function (type, index) {
                if (type == "localStorage") {
                    return window.localStorage.key(index);
                }
                else {
                    return window.sessionStorage.key(index);
                }
            };
            return Storage;
        }());
        function Load() {
            var storage = {
                Storage: new Storage()
            };
            if (window['DC']) {
                window['DC'] = __assign({}, window['DC'], storage);
            }
            else {
                window['DC'] = __assign({}, storage);
            }
        }
        Storage_1.Load = Load;
    })(Storage = DC.Storage || (DC.Storage = {}));
})(DC || (DC = {}));
DC.Storage.Load();
//# sourceMappingURL=DC.Storage.js.map