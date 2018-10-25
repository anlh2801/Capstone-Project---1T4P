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

    public String getTicketEstimationTime() {
        return ticketEstimationTime;
    }

    public void setTicketEstimationTime(String ticketEstimationTime) {
        this.ticketEstimationTime = ticketEstimationTime;
    }

    public Ticket(Integer deviceId, String desciption) {
        this.deviceId = deviceId;
        this.desciption = desciption;
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
