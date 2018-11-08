package com.odts.activities;

import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import com.abdeveloper.library.MultiSelectDialog;
import com.abdeveloper.library.MultiSelectModel;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.models.Ticket;
import com.odts.services.DeviceService;
import com.odts.services.RequestService;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;

import java.sql.BatchUpdateException;
import java.util.ArrayList;
import java.util.List;

public class AddRequestLayoutActivity extends AppCompatActivity {
    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;
    private DeviceService _deviceService;
    private RequestService _requestService;
    Integer agencyId = 0;
    int serviceItemId;
    Button btnSave;
    Button btnCancle;
    String requestName;
    ArrayList<Device> listTicket;
    MultiSelectDialog multiSelectDialog;
    EditText txtRequestDesciption;
    EditText txtPhone;
    private EditText editDevice;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_request_layout);
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);
        getAllServiceITSupportForAgency(agencyId);
        btnSave = (Button) findViewById(R.id.btnSaveRequest);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                createRequest();
            }
        });
        btnCancle = (Button) findViewById(R.id.btnCancle);
        btnCancle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });


    }

    private void getAllServiceITSupportForAgency(final int agencyId) {
        _serviceITSupportService = new ServiceITSupportService();
        _serviceITSupportService.getAllServiceITSupport(this, agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                getAllServiceItemByServiceId(serviceITSupports.get(0).getServiceITSupportId());
                getAllDeviceByAgencyIdAndServiceItem(agencyId, (serviceITSupports.get(0).getServiceITSupportId()));
                final List<ServiceITSupport> ServiceITSupportList = new ArrayList<ServiceITSupport>();
                Spinner spinnerService = (Spinner) findViewById(R.id.spinner1);
                for (final ServiceITSupport item : serviceITSupports) {
                    ServiceITSupportList.add(item);
                }
                final ArrayAdapter<ServiceITSupport> dataAdapter = new ArrayAdapter<ServiceITSupport>(AddRequestLayoutActivity.this, android.R.layout.simple_spinner_item, ServiceITSupportList);
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinnerService.setAdapter(dataAdapter);
                spinnerService.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                        ServiceITSupport serviceITSupport = (ServiceITSupport) adapterView.getSelectedItem();
                        getAllServiceItemByServiceId(serviceITSupport.getServiceITSupportId());
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> adapter) {
                    }
                });

            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    public void getAllServiceItemByServiceId(final int serviceId) {
        _serviceItem = new ServiceItemService();
        _serviceItem.getAllServiceItemByServiceId(this, serviceId, new CallBackData<ArrayList<ServiceItem>>() {
            @Override
            public void onSuccess(ArrayList<ServiceItem> serviceItems) {
                Spinner spinner = (Spinner) findViewById(R.id.spinner2);
                List<ServiceItem> categories = new ArrayList<ServiceItem>();
                for (ServiceItem item : serviceItems) {
                    categories.add(item);
                }
                final ArrayAdapter<ServiceItem> dataAdapter = new ArrayAdapter<ServiceItem>(AddRequestLayoutActivity.this, android.R.layout.simple_spinner_item, categories);
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner.setAdapter(dataAdapter);
                spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                        ServiceItem serviceItem = (ServiceItem) adapterView.getSelectedItem();
                        serviceItemId = serviceItem.getServiceItemId();
                        requestName = serviceItem.getServiceItemName();
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> adapter) {
                    }
                });
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void getAllDeviceByAgencyIdAndServiceItem(int agencyId, int serviceId) {
        _deviceService = new DeviceService();
        editDevice = (EditText) findViewById(R.id.editTextDevice);
        txtPhone = (EditText) findViewById(R.id.editText);
        txtRequestDesciption = (EditText) findViewById(R.id.editText2);
        final ArrayList<MultiSelectModel> listDevices = new ArrayList<>();
        _deviceService.getAllDeviceByAgencyIdAndServiceItem(AddRequestLayoutActivity.this, agencyId, serviceId, new CallBackData<ArrayList<Device>>() {
            @Override
            public void onSuccess(ArrayList<Device> devices) {

                for (int i = 0; i < devices.size(); i++) {
                    listDevices.add(new MultiSelectModel(devices.get(i).getDeviceId(), devices.get(i).getDeviceName()));
                }
                final ArrayList<Integer> alreadyTickets = new ArrayList<>();
                editDevice.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        multiSelectDialog = new MultiSelectDialog()
                                .title("Thiết bị") //setting title for dialog
                                .titleSize(25)
                                .positiveText("OK")
                                .negativeText("Cancel")
                                .setMinSelectionLimit(0)
                                .setMaxSelectionLimit(listDevices.size())
                                .preSelectIDsList(alreadyTickets) //List of ids that you need to be selected
                                .multiSelectList(listDevices) // the multi select model list with ids and name
                                .onSubmit(new MultiSelectDialog.SubmitCallbackListener() {
                                    @Override
                                    public void onSelected(ArrayList<Integer> selectedIds, ArrayList<String> selectedNames, String dataString) {
                                        //will return list of selected IDS
                                        listTicket = new ArrayList<>();
                                        Device tic = new Device();
                                        for (int i = 0; i < selectedIds.size(); i++) {
                                            tic.setDeviceId(selectedIds.get(i));
                                            listTicket.add(tic);
                                        }
                                        StringBuilder sb = new StringBuilder();
                                        boolean foundOne = false;
                                        for (int i = 0; i < selectedIds.size(); ++i) {
                                            if (foundOne) {
                                                sb.append(", ");
                                            }
                                            foundOne = true;
                                            sb.append(selectedNames.get(i));
                                        }
                                        editDevice.setText(sb.toString());
                                    }

                                    @Override
                                    public void onCancel() {

                                    }
                                });
                        multiSelectDialog.show(getSupportFragmentManager(), "multiSelectDialog");
                    }
                });
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    public void createRequest() {
        _requestService = new RequestService();
        List listTickets = new ArrayList<Ticket>();
        for (Device item : listTicket) {
            Ticket ticc = new Ticket();
            ticc.setDeviceId(item.getDeviceId());
            ticc.setDesciption("Thuộc agencyId: " + agencyId + " thiết bị: " + item.getDeviceName() + "Vấn đề: " + requestName.toString());
            listTickets.add(ticc);
        }
        Request request = new Request();
        request.setPhoneNumber(txtPhone.getText().toString());
        request.setAgencyId(agencyId);
        request.setRequestCategoryId(3);
        request.setServiceItemId(serviceItemId);
        request.setRequestDesciption(txtRequestDesciption.getText().toString());
        request.setRequestName(requestName.toString());
        request.setTicket(listTickets);

        _requestService.createRequest(AddRequestLayoutActivity.this, request);
    }
}