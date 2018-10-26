package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Ticket {
    @SerializedName("deviceId")
    private Integer deviceId;
    @SerializedName("desciption")
    private String desciption;
    @SerializedName("ITSupporterName")
    private String iTSupporterName;
    @SerializedName("TicketEstimationTime")
    private String ticketEstimationTime;
    @SerializedName("StartTime")
    private String startTime;

    @SerializedName("EndTime")
    private String endTime;

    @SerializedName("CreateDate")
    private String createDate;

    @SerializedName(("Current_TicketStatus"))
    private Integer crStatus;

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }

    public Integer getCrStatus() {
        return crStatus;
    }

    public void setCrStatus(Integer crStatus) {
        this.crStatus = crStatus;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }
    public Ticket(String iTSupporterName, Integer crStatus, String ticketEstimationTime) {
        this.iTSupporterName = iTSupporterName;
        this.crStatus = crStatus;
        this.ticketEstimationTime = ticketEstimationTime;
    }

    public String getStartTime() {
        return startTime;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public String getTicketEstimationTime() {
        return ticketEstimationTime;
    }

    public void setTicketEstimationTime(String ticketEstimationTime) {
        this.ticketEstimationTime = ticketEstimationTime;
    }


    public String getiTSupporterName() {
        return iTSupporterName;
    }

    public void setiTSupporterName(String iTSupporterName) {
        this.iTSupporterName = iTSupporterName;
    }

    public Integer getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(Integer deviceId) {
        this.deviceId = deviceId;
    }

    public String getDesciption() {
        return desciption;
    }

    public void setDesciption(String desciption) {
        this.desciption = desciption;
    }

    public Ticket() {
    }
}
