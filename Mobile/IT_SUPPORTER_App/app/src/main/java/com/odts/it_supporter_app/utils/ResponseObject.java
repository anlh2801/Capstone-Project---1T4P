package com.odts.it_supporter_app.utils;

import com.google.gson.annotations.SerializedName;

public class ResponseObject<T> {
    @SerializedName("ObjReturn")
    private T ObjReturn;

    @SerializedName("IsError")
    private boolean isError;

    @SerializedName("ErrorMessage")
    private String errorMessage;

    @SerializedName("WarningMessage")
    private String warningMessage;

    @SerializedName("SuccessMessage")
    private String successMessage;

    public ResponseObject(T objReturn) {
        ObjReturn = objReturn;
    }

    public T getObjReturn() {
        return ObjReturn;
    }

    public void setObjReturn(T objReturn) {
        ObjReturn = objReturn;
    }

    public boolean isError() {
        return isError;
    }

    public void setError(boolean error) {
        isError = error;
    }

    public String getErrorMessage() {
        return errorMessage;
    }

    public void setErrorMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }

    public String getWarningMessage() {
        return warningMessage;
    }

    public void setWarningMessage(String warningMessage) {
        this.warningMessage = warningMessage;
    }

    public String getSuccessMessage() {
        return successMessage;
    }

    public void setSuccessMessage(String successMessage) {
        this.successMessage = successMessage;
    }
}
