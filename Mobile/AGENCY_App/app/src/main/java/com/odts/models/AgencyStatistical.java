package com.odts.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class AgencyStatistical {
    @SerializedName("ServiceId")
    private Integer serviceId;
    @SerializedName("ServiceName")
    private String serviceName;
    @SerializedName("Statuses")
    private List<Status> statuses;

    public Integer getServiceId() {
        return serviceId;
    }

    public void setServiceId(Integer serviceId) {
        this.serviceId = serviceId;
    }

    public String getServiceName() {
        return serviceName;
    }

    public void setServiceName(String serviceName) {
        this.serviceName = serviceName;
    }

    public List<Status> getStatuses() {
        return statuses;
    }

    public void setStatuses(List<Status> statuses) {
        this.statuses = statuses;
    }
}
