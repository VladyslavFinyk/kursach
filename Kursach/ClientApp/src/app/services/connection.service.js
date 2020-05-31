"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var signalR = require("@microsoft/signalr");
var Connection = /** @class */ (function () {
    function Connection() {
    }
    Connection.prototype.initialiseSignalRConnection = function () {
        var connection = new signalR.HubConnectionBuilder().build();
        connection.start().then(function () {
            console.log(connection.invoke("GetHardwareInfo"));
        }).catch(function () {
            console.log("error");
        });
    };
    return Connection;
}());
exports.Connection = Connection;
//# sourceMappingURL=connection.service.js.map