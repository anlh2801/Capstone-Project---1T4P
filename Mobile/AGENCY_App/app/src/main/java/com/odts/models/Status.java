package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Status {
    @SerializedName("StatusId")
    private Integer statusId;
    @SerializedName("StatusName")
    private String statusName;
    @SerializedName("NumberOfStatus")
    private String numberOfStatus;

    public Integer getStatusId() {
        return statusId;
    }

    public void setStatusId(Integer statusId) {
        this.statusId = statusId;
    }

    public String getStatusName() {
        return statusName;
    }

    public void setStatusName(String statusName) {
        this.statusName = statusName;
    }

    public String getNumberOfStatus() {
        return numberOfStatus;
    }

    public void setNumberOfStatus(String numberOfStatus) {
        this.numberOfStatus = numberOfStatus;
    }
}
