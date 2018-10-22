package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class ServiceItem {
    @SerializedName("ServiceItemId")
    private Integer serviceItemId;
    @SerializedName("ServiceItemName")
    private String serviceItemName;
    @SerializedName("ServiceItemPrice")
    private Double serviceItemPrice;
    @SerializedName("Description")
    private String description;
    @SerializedName("CreateDate")
    private String createDate;
    @SerializedName("UpdateDate")
    private String updateDate;
    @SerializedName("ServiceId")
    private Integer serviceId;

    public Integer getServiceItemId() {
        return serviceItemId;
    }

    public void setServiceItemId(Integer serviceItemId) {
        this.serviceItemId = serviceItemId;
    }

    public String getServiceItemName() {
        return serviceItemName;
    }

    public void setServiceItemName(String serviceItemName) {
        this.serviceItemName = serviceItemName;
    }

    public Double getServiceItemPrice() {
        return serviceItemPrice;
    }

    public void setServiceItemPrice(double serviceItemPrice) {
        this.serviceItemPrice = serviceItemPrice;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
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

    public void setServiceItemPrice(Double serviceItemPrice) {
        this.serviceItemPrice = serviceItemPrice;
    }

    public Integer getServiceId() {
        return serviceId;
    }

    public void setServiceId(Integer serviceId) {
        this.serviceId = serviceId;
    }
}
