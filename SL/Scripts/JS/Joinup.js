define(["require", "exports", "knockout", "jquery", "./MasterMember", "./MasterBank", "./MasterBranch", "./MasterRace", "./MASTERCITY", "./MASTERSTATE", "./MasterCountry", "./MasterNominee", "./MasterGuardian", "./MasterRelation", "bootstrap", "jqueryui", "knockout-jqAutocomplete"], function (require, exports, ko, $, MasterMember_1, MasterBank_1, MasterBranch_1, MasterRace_1, MASTERCITY_1, MASTERSTATE_1, MasterCountry_1, MasterNominee_1, MasterGuardian_1, MasterRelation_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Joinup = /** @class */ (function () {
        function Joinup() {
            var _this = this;
            this.data = new MasterMember_1.MASTERMEMBER();
            this.dataGuardian = new MasterGuardian_1.MASTERGUARDIAN();
            this.nomineeList = ko.observableArray();
            this.AddNominee();
            this.nominee = ko.observable("No");
            this.Guardian = ko.observable("No");
            this.bankList = MasterBank_1.MASTERBANK.toList();
            this.branchList = ko.computed(function () { return MasterBranch_1.MASTERBRANCH.toList(_this.data.BANK_CODE()); });
            this.raceList = MasterRace_1.MASTERRACE.toList();
            this.cityList = MASTERCITY_1.MASTERCITY.toList();
            this.stateList = MASTERSTATE_1.MASTERSTATE.toList();
            this.countryList = MasterCountry_1.MASTERCOUNTRY.toList();
            this.relationList = MasterRelation_1.MASTERRELATION.toList();
        }
        Joinup.prototype.MemberAttachment = function (Member_Code, AttachmentName, file) {
            if (file != undefined) {
                var mFiles = new FormData();
                mFiles.append('Member_Code', Member_Code);
                mFiles.append('AttachmentName', AttachmentName);
                mFiles.append('AttachmentFile', file.files[0]);
                $.post('http://localhost/MembershipTest/MasterMember/Attachment', mFiles, function (res) {
                });
            }
        };
        Joinup.prototype.btnSave = function () {
            var _this = this;
            var d = ko.toJS(this.data);
            console.log(d);
            $.post('http://localhost/MembershipTest/MasterMember/Insert', d, function (resMember) {
                console.log(resMember);
                if (resMember.isSaved) {
                    _this.MemberAttachment(resMember.MEMBER_CODE, "fPhoto", $('#fPhoto')[0]);
                    _this.MemberAttachment(resMember.MEMBER_CODE, "fDSign", $('#fDSign')[0]);
                    _this.MemberAttachment(resMember.MEMBER_CODE, "fIC", $('#fIC')[0]);
                    _this.MemberAttachment(resMember.MEMBER_CODE, "fELetter", $('#fELetter')[0]);
                    if (_this.nominee() == "Yes") {
                        ko.utils.arrayForEach(_this.nomineeList(), function (n) {
                            n.MEMBER_CODE(resMember.MEMBER_CODE);
                            var dN = ko.toJS(n);
                            $.post('http://localhost/MembershipTest/Nominee/Insert', dN, function (resNominee) {
                            });
                        });
                    }
                    if (_this.Guardian() == "Yes") {
                        _this.dataGuardian.MEMBER_CODE(resMember.MEMBER_CODE);
                        var dG = ko.toJS(_this.dataGuardian);
                        $.post('http://localhost/MembershipTest/Guardian/Insert', dG, function (resGuardian) {
                        });
                    }
                }
            });
        };
        Joinup.prototype.AddNominee = function () {
            this.nomineeList.push(new MasterNominee_1.MASTERNOMINEE());
        };
        Joinup.prototype.RemoveNominee = function (data) {
            if (confirm("Are you remove this nominee?")) {
                this.nomineeList.remove(function (x) {
                    return x == data;
                });
            }
        };
        return Joinup;
    }());
    exports.Joinup = Joinup;
    Joinup.joinupVM = new Joinup();
    ko.applyBindings(Joinup.joinupVM);
    var dateOption = { dateFormat: 'dd/mm/yy' };
    $('#dob').datepicker(dateOption);
    $('#doe').datepicker(dateOption);
    $('#dob').change(function (e) {
        var dt = $(e.target).datepicker('getDate');
        Joinup.joinupVM.data.DATEOFBIRTH(dt);
    });
    $('#doe').change(function (e) {
        var dt = $(e.target).datepicker('getDate');
        Joinup.joinupVM.data.DATEOFEMPLOYMENT(dt);
    });
});
//# sourceMappingURL=Joinup.js.map