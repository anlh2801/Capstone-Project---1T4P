package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class DeviceHistory_Ticket {
    @SerializedName("TicketId")
    private Integer ticketId;
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("DeviceId")
    private Integer deviceId;
    @SerializedName("ServiceItemName")
    private String serviceItemName;
    @SerializedName("Desciption")
    private String desciption;
    @SerializedName("CreateDate")
    private String createDate;
    @SerializedName("UpdateDate")
    private String updateDate;

    public DeviceHistory_Ticket() {
    }

    public Integer getTicketId() {
        return ticketId;
    }

    public void setTicketId(Integer ticketId) {
        this.ticketId = ticketId;
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public Integer getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(Integer deviceId) {
        this.deviceId = deviceId;
    }

    public String getServiceItemName() {
        return serviceItemName;
    }

    public void setServiceItemName(String serviceItemName) {
        this.serviceItemName = serviceItemName;
    }

    public String getDesciption() {
        return desciption;
    }

    public void setDesciption(String desciption) {
        this.desciption = desciption;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }

    public String getUpdateDate() {
        return updateDate;
    }

    public void setUpdateDate(String updateDate) {
        this.updateDate = updateDate;
    }
}
