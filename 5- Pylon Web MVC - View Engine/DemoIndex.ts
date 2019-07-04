namespace hewClientScripts {
    export class DemoIndex implements powClientScripts.System.IEntryPoint {

        public OnNeedsDateChange() {
            let needsDate: number = powClientScripts.Helpers.UI.GetInputValue($("#NeedsDateDropdown"));
            powClientScripts.Helpers.UI.SetComponentEnabled($("#DemoDatePicker"), needsDate != 1);
        }

        public async OnSaveClick() {
            let formData = powClientScripts.Helpers.UI.SerializeForm($("#mainForm"));
            let result = await powClientScripts.Helpers.AjaxCall<powAjaxResult>({
                method: "POST",
                url: "/hewDemo/Save",
                data: formData
            });
            if (!result.success) {
                powClientScripts.Helpers.Dialogs.ShowAjaxFailure(result);
            }

        }

    }
}