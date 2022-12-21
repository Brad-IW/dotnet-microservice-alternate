FROM curlimages/curl

COPY build-services.sh /tmp/build-services.sh

WORKDIR /tmp

USER root
RUN chmod +x ./build-services.sh
USER 1001

ENTRYPOINT [ "/tmp/build-services.sh" ]

# COPY build-services.sh /tmp/build-services.sh

# WORKDIR /tmp

# USER root
# RUN chmod +x /tmp/build-services.sh
# USER 1001

# # ENTRYPOINT ["tail", "-f", "/dev/null"]
# ENTRYPOINT [ "/tmp/build-services.sh" ]