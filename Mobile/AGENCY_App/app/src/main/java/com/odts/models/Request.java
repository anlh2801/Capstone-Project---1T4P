package com.odts.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Request {

    @SerializedName("IsError")
    private boolean isError;

    @SerializedName("ErrorMessage")
    private String errorMessage;

    @SerializedName("WarningMessage")
    private String warningMessage;

    @SerializedName("SuccessMessage")
    private String successMessage;
    @SerializedName("agencyId")
    private Integer agencyId;
    @SerializedName("requestCategoryId")
    private Integer requestCategoryId;
    @SerializedName("serviceItemId")
    private Integer serviceItemId;
    @SerializedName("requestName")
    private String requestName;
    @SerializedName("ticket")
    private List<Ticket> ticket;

    public Request(Integer agencyId, Integer requestCategoryId, Integer serviceItemId, String requestName, List<Ticket> ticket) {
        this.agencyId = agencyId;
        this.requestCategoryId = requestCategoryId;
        this.serviceItemId = serviceItemId;
        this.requestName = requestName;
        this.ticket = ticket;
    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public Integer getRequestCategoryId() {
        return requestCategoryId;
    }

    public void setRequestCategoryId(Integer requestCategoryId) {
        this.requestCategoryId = requestCategoryId;
    }

    public Integer getServiceItemId() {
        return serviceItemId;
    }

    public void setServiceItemId(Integer serviceItemId) {
        this.serviceItemId = serviceItemId;
    }

    public String getRequestName() {
        return requestName;
    }

    public void setRequestName(String requestName) {
        this.requestName = requestName;
    }

    public List<Ticket> getTicket() {
        return ticket;
    }

    public void setTicket(List<Ticket> ticket) {
        this.ticket = ticket;
    }

    public Request() {
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
