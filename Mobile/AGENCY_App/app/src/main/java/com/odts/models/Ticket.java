package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Ticket {
    @SerializedName("deviceId")
    private Integer deviceId;
    @SerializedName("desciption")
    private String desciption;

    public Ticket(Integer deviceId, String desciption) {
        this.deviceId = deviceId;
        this.desciption = desciption;
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
