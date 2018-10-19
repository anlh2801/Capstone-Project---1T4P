package com.odts.utils;

import com.google.gson.annotations.SerializedName;
import com.odts.models.Company;

import java.util.ArrayList;

public class ResponseObject<T> {
    @SerializedName("ObjReturn")
    private T companyList;

    @SerializedName("IsError")
    private boolean isError;

    @SerializedName("ErrorMessage")
    private String errorMessage;

    @SerializedName("WarningMessage")
    private String warningMessage;

    @SerializedName("SuccessMessage")
    private String successMessage;

    public T getCompanyList() {
        return companyList;
    }

    public void setCompanyList(T companyList) {
        this.companyList = companyList;
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
