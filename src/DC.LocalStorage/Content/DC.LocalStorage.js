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
    var LocalStorage;
    (function (LocalStorage_1) {
        var LocalStorage = /** @class */ (function () {
            function LocalStorage() {
            }
            // 存储到本地持久化缓存
            LocalStorage.prototype.SetItem = function (key, data) {
                window.localStorage.setItem(key, data);
            };
            // 从本地持久化缓存中读取数据
            LocalStorage.prototype.GetItem = function (key) {
                return window.localStorage.getItem(key);
            };
            // 删除数据项
            LocalStorage.prototype.RemoveItem = function (key) {
                window.localStorage.removeItem(key);
            };
            // 删除所有数据
            LocalStorage.prototype.Clear = function () {
                window.localStorage.clear();
            };
            // 获取本地持久化缓存中的数量
            LocalStorage.prototype.Length = function () {
                return window.localStorage.length;
            };
            // 获取本地持久化缓存中的指定序号的Key名
            LocalStorage.prototype.Key = function (index) {
                return window.localStorage.key(index);
            };
            return LocalStorage;
        }());
        function Load() {
            var localStorage = {
                LocalStorage: new LocalStorage()
            };
            if (window['DC']) {
                window['DC'] = __assign({}, window['DC'], localStorage);
            }
            else {
                window['DC'] = __assign({}, localStorage);
            }
        }
        LocalStorage_1.Load = Load;
    })(LocalStorage = DC.LocalStorage || (DC.LocalStorage = {}));
})(DC || (DC = {}));
DC.LocalStorage.Load();
//# sourceMappingURL=DC.LocalStorage.js.map