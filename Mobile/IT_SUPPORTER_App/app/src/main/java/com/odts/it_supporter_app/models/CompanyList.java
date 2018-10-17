package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.ArrayList;

public class CompanyList {

    @SerializedName("ObjReturn")
    private ArrayList<Company> companyList;

    @SerializedName("IsError")
    private boolean isError;

    @SerializedName("ErrorMessage")
    private String errorMessage;

    @SerializedName("WarningMessage")
    private String warningMessage;

    @SerializedName("SuccessMessage")
    private String successMessage;

    public ArrayList<Company> getCompanyList() {
        return companyList;
    }

    public void setCompanyList(ArrayList<Company> companyList) {
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
        successMessage = successMessage;
    }
}
