package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class Ticket {
    @SerializedName("TicketId")
    private Integer ticketId;
    @SerializedName("DeviceId")
    private Integer deviceId;
    @SerializedName("DeviceName")
    private String deviceName;
    @SerializedName("DeviceCode")
    private String deviceCode;

    public String getDeviceCode() {
        return deviceCode;
    }

    public void setDeviceCode(String deviceCode) {
        this.deviceCode = deviceCode;
    }

    public Integer getTicketId() {
        return ticketId;
    }

    public void setTicketId(Integer ticketId) {
        this.ticketId = ticketId;
    }

    public Integer getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(Integer deviceId) {
        this.deviceId = deviceId;
    }

    public String getDeviceName() {
        return deviceName;
    }

    public void setDeviceName(String deviceName) {
        this.deviceName = deviceName;
    }
}
